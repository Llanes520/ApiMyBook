using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using MyBook.Domain.Domain.Dto.Editoriales;
using MyBook.Domain.Domain.Services.IServices;
using MyBookShop.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Domain.Domain.Services
{
    public class EditorialServices : IEditorialServices
    {
        #region Attribute
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public EditorialServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<EditorialDto> GetAllEditorial()
        {
            List<EditorialEntity> typeEditorial = _unitOfWork.EditorialRepository.GetAll().ToList();

            List<EditorialDto> list = typeEditorial.Select(x => new EditorialDto
            {
                IdEditorial = x.IdEditorial,
                Nombre = x.Nombre,
                Sede = x.Sede

            }).ToList();


            return list;
        }

        public async Task<ResponseDto> DeleteEditorialAsync(int idEditorial)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.EditorialRepository.Delete(idEditorial);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente la Editorial";
            else
                response.Message = "Hubo un error al eliminar la Editorial, por favor vuelva a intentalo";

            return response;
        }

        public async Task<bool> InsertEditorialAsync(EditorialDto editorial)
        {
            var editorialEntity = new EditorialEntity()
            {
                Nombre = editorial.Nombre,
                Sede = editorial.Sede
            };

            _unitOfWork.EditorialRepository.Insert(editorialEntity);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateEditorialAsync(EditorialDto Edit)
        {
            bool result = false;

            EditorialEntity editorialEntity = _unitOfWork.EditorialRepository.FirstOrDefault(x => x.IdEditorial == Edit.IdEditorial);
            if (editorialEntity != null)
            {
                editorialEntity.Nombre = Edit.Nombre;
                editorialEntity.Sede = Edit.Sede;

                _unitOfWork.EditorialRepository.Update(editorialEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
        #endregion
    }
}
