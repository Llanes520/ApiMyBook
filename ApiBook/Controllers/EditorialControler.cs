using ApiBook.Handler;
using Common.Utils.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBook.Domain.Domain.Dto.Editoriales;
using MyBook.Domain.Domain.Services.IServices;
using MyBookShop.Domain.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBook.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class EditorialControler : ControllerBase
    {
        #region Attribute
        private readonly IEditorialServices _editorialServices;
        #endregion

        #region Builder
        public EditorialControler(IEditorialServices editorialServices)
        {
            _editorialServices = editorialServices;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Obtener todas las editoriales
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllEditorial")]
        public IActionResult GetAllEditorial()
        {
            List<EditorialDto> list = _editorialServices.GetAllEditorial();

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// Eliminar una editorial en específico
        /// </summary>
        /// <param name="idEditorial"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteEditorial")]
        public async Task<IActionResult> DeleteEditorial(int idEditorial)
        {
            IActionResult response;
            ResponseDto result = await _editorialServices.DeleteEditorialAsync(idEditorial);
            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return response;
        }

        /// <summary>
        /// Agregar una nueva editorial 
        /// </summary>
        /// <param name="editorial"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertEditorial")]
        public async Task<IActionResult> InsertEditorial(EditorialDto editorial)
        {
            IActionResult response;

            bool result = await _editorialServices.InsertEditorialAsync(editorial);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemInserted : GeneralMessages.ItemNoInserted
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }

        /// <summary>
        /// Actualziar una editorial en específico
        /// </summary>
        /// <param name="Edit"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateEditorial")]
        public async Task<IActionResult> UpdateEditorial(EditorialDto Edit)
        {
            IActionResult response;

            bool result = await _editorialServices.UpdateEditorialAsync(Edit);
            ResponseDto responseDto = new ResponseDto()
            {
                IsSuccess = result,
                Result = result,
                Message = result ? GeneralMessages.ItemUpdated : GeneralMessages.ItemNoUpdated
            };

            if (result)
                response = Ok(responseDto);
            else
                response = BadRequest(responseDto);

            return response;
        }
        #endregion
    }
}
