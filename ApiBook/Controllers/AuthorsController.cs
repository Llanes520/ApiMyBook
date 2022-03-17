using ApiBook.Handler;
using Common.Utils.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBook.Domain.Domain.Dto;
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
    public class AuthorsController : Controller
    {
        #region Atributes
        private readonly IAuthorsServices _authorsServices;
        #endregion

        #region Builder
        public AuthorsController(IAuthorsServices authorsServices)
        {
            _authorsServices = authorsServices;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Obtener todos los Autores
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllAthors")]
        public IActionResult GetAllAthors()
        {
            List<AuthorsDto> list = _authorsServices.GetAllAthors();

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };

            return Ok(response);
        }      

  
        /// <summary>
        /// Eliminar un Autor en específico
        /// </summary>
        /// <param name="idAthor"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteAuthors")]
        public async Task<IActionResult> DeleteAuthors(int idAthor)
        {
            IActionResult response;
            ResponseDto result = await _authorsServices.DeleteAuthorsAsync(idAthor);
            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return response;
        }

        /// <summary>
        /// Agregar un nuevo Autor
        /// </summary>
        /// <param name="Author"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertAuthors")]
        public async Task<IActionResult> InsertAuthors(AuthorsDto Author)
        {
            IActionResult response;

            bool result = await _authorsServices.InsertAuthorsAsync(Author);
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
        /// Actualziar un autor en específico
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(AuthorsDto author)
        {
            IActionResult response;

            bool result = await _authorsServices.UpdateAuthorsAsync(author);
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
