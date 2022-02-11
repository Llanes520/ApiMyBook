using Infraestructure.Entity.Models;
using MyBook.Domain.Domain.Dto;
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

        List<UserEntity> GetAllUser();
        UserEntity GetUser(int idUser);
        Task<bool> UpdateUser(UserEntity user);
        Task<bool> DeleteUser(int idUser);
        Task<bool> CreateUser(UserEntity data);

    }
}
