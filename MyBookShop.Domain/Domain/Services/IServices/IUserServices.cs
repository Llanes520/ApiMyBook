using Infraestructure.Entity.Models;
using MyBook.Domain.Domain.Dto;
using MyBook.Domain.Domain.Dto.Users;
using MyBookShop.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBookShop.Domain.Domain.Services.Iservices
{
    public interface IUserServices
    {
        #region Auth
        TokenDto Login(LoginDto user);
        Task<ResponseDto> Register(UserDto data);
        #endregion

        List<UpdateUserDto> GetAllUser();
        Task<ResponseDto> DeleteUser(int idUser);
        Task<bool> InsertUser(InsertUserDto data);
        Task<bool> UpdateUser(UpdateUserDto user);

    }
}
