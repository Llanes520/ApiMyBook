using ApiBook.Handler;
using Common.Utils.Resource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBook.Domain.Domain.Dto.Users;
using MyBookShop.Domain.Domain.Dto;
using MyBookShop.Domain.Domain.Services.Iservices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBook.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class UserController : Controller
    {
        #region Atribute
        private readonly IUserServices _userServices;
        #endregion

        #region Builder
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Obtener todos los Usuarios
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetAllUser()
        {
            List<UpdateUserDto> list = _userServices.GetAllUser();

            ResponseDto response = new ResponseDto()
            {
                IsSuccess = true,
                Result = list,
                Message = string.Empty
            };

            return Ok(response);
        }

        /// <summary>
        /// Eliminar un usuario en específico
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int idUser)
        {
            IActionResult response;
            ResponseDto result = await _userServices.DeleteUser(idUser);
            if (result.IsSuccess)
                response = Ok(result);
            else
                response = BadRequest(result);

            return response;
        }

        /// <summary>
        /// Agregar un nuevo usuario (No agregar el "idRol")
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPost]
        [Route("InsertUser")]
        public async Task<IActionResult> InsertUser(InsertUserDto data)
        {
            IActionResult response;

            bool result = await _userServices.InsertUser(data);
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
        /// Actualziar un usuario en específico
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="200">OK! </response>
        /// <response code="400">Business Exception</response>
        /// <response code="500">Oops! Can't process your request now</response>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto user)
        {
            IActionResult response;

            bool result = await _userServices.UpdateUser(user);
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
