using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Security;
using MyBook.Domain.Domain.Dto;
using MyBook.Domain.Domain.Services.IServices;
using MyBookShop.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBook.Domain.Domain.Services
{
    public class AuthorsServices : IAuthorsServices
    {
        #region Atributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public AuthorsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<AuthorsDto> GetAllAthors()
        {
            var pets = _unitOfWork.AuthorsRepository.GetAll(p => p.Authors_Has_BooksEntities).ToList();

            List<AuthorsDto> list = pets.Select(x => new AuthorsDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,

            }).ToList();


            return list;
        }

        public async Task<ResponseDto> DeleteAuthorsAsync(int idAuthor)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.AuthorsRepository.Delete(idAuthor);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente el libro";
            else
                response.Message = "Hubo un error al eliminar el libro, por favor vuelva a intentalo";

            return response;
        }

        public async Task<bool> InsertAuthorsAsync(AuthorsDto Author)
        {
            var authorsEntity = new AuthorsEntity()
            {
                Nombre = Author.Nombre,
                Apellidos = Author.Apellidos,
            };

            _unitOfWork.AuthorsRepository.Insert(authorsEntity);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateAuthorsAsync(AuthorsDto author)
        {
            bool result = false;

            AuthorsEntity authorsEntity = _unitOfWork.AuthorsRepository.FirstOrDefault(x => x.Id == author.Id);
            if (authorsEntity != null)
            {
                authorsEntity.Nombre = author.Nombre;
                authorsEntity.Apellidos = author.Apellidos;

                _unitOfWork.AuthorsRepository.Update(authorsEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
        #endregion
    }
}
