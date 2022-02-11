using ApiBook.Handler;
using Common.Utils.Constant;
using Common.Utils.Resource;
using Common.Utils.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBook.Domain.Domain.Dto;
using MyBook.Domain.Domain.Dto.Books;
using MyBook.Domain.Domain.Services.IServices;
using MyBookShop.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBook.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class BooksControler : ControllerBase
    {
        #region Attributes
        private readonly IBookService _bookService;
        #endregion

        #region Builder
        public BooksControler(IBookService bookService)
        {
            _bookService = bookService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Obtener todas los libros de un usuario
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllBook")]
        public IActionResult GetAllBook()
        {
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);
            List<ConsultBookDto> list = _bookService.GetAllBook(Convert.ToInt32(idUser));

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };

            return Ok(response);
        }

        /// <summary>
        /// Obtener todos los tipos de libros
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllTypeBook")]
        public IActionResult GetAllTypeBook()
        {
            List<TypeBookDto> result = _bookService.GetAllTypeBook();
            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = result,
                Message = string.Empty
            };
            return Ok(response);
        }

        /// <summary>
        /// Eliminar un libro en específico
        /// </summary>
        /// <param name="idbook"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int idbook)
        {
            IActionResult response;
            ResponseDto result = await _bookService.DeleteBookAsync(idbook);
            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return response;
        }

        /// <summary>
        /// Agregar un nuevo libro (para el usuario que hace el proceso)
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertBook")]
        public async Task<IActionResult> InsertBook(InsertBookDto pet)
        {
            IActionResult response;
            string idUser = Utils.GetClaimValue(Request.Headers["Authorization"], TypeClaims.IdUser);

            bool result = await _bookService.InsertBookAsync(pet, Convert.ToInt32(idUser));
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
        /// Actualziar un libro en específico
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdatePet")]
        public async Task<IActionResult> UpdatePet(BookDto book)
        {
            IActionResult response;

            bool result = await _bookService.UpdateBookAsync(book);
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
