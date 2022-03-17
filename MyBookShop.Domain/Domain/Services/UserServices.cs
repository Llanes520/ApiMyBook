using Common.Utils.Constant;
using Common.Utils.Enums;
using Common.Utils.Exeption;
using Common.Utils.Resource;
using Common.Utils.Utils;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyBook.Domain.Domain.Dto;
using MyBook.Domain.Domain.Dto.Users;
using MyBookShop.Domain.Domain.Dto;
using MyBookShop.Domain.Domain.Services.Iservices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Common.Utils.Enums.Enums;

namespace MyBookShop.Domain.Domain.Services
{
    public class UserServices : IUserServices
    {
        #region Atributhe
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        #endregion

        #region Builder
        public UserServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        #endregion

        #region authentication

        public TokenDto Login(LoginDto login)
        {
            UserEntity user = _unitOfWork.UserRepository.FirstOrDefault(x => x.Email == login.UserName
                                                                            && x.Password == login.Password,
                                                                           r => r.RolUserEntities);
            if (user == null)
                throw new BusinessException(GeneralMessages.BadCredentials);

            //TOKEN
            return GenerateTokenJWT(user);
        }

        public TokenDto GenerateTokenJWT(UserEntity userEntity)
        {
            IConfigurationSection tokenAppSetting = _configuration.GetSection("Tokens");

            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenAppSetting.GetSection("Key").Value));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);

            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(TypeClaims.IdUser,userEntity.IdUser.ToString()),
                new Claim(TypeClaims.UserName,userEntity.FullName),
                new Claim(TypeClaims.Email,userEntity.Email),
                new Claim(TypeClaims.IdRol,string.Join(",",userEntity.RolUserEntities.Select(x=>x.IdRol))),
            };

            var _payload = new JwtPayload(
                    issuer: tokenAppSetting.GetSection("Issuer").Value,
                    audience: tokenAppSetting.GetSection("Audience").Value,
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(60)
                );

            var _token = new JwtSecurityToken(
                    _header,
                    _payload
                );

            TokenDto token = new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(_token),
                Expiration = Utils.ConvertToUnixTimestamp(_token.ValidTo),
            };
            return token;
        }

        #endregion

        #region Methods
        public List<UpdateUserDto> GetAllUser()
        {
            var users = _unitOfWork.UserRepository.GetAll().ToList();

            List<UpdateUserDto> list = users.Select(x => new UpdateUserDto
            {
                IdUser = x.IdUser,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,

            }).ToList();


            return list;

        }

        public async Task<bool> UpdateUser(UpdateUserDto user)
        {
            bool result = false;

            UserEntity userEntity = _unitOfWork.UserRepository.FirstOrDefault(x => x.IdUser == user.IdUser);
            if (userEntity != null)
            {
                userEntity.Name = user.Name;
                userEntity.LastName = user.LastName;
                userEntity.Email = user.Email;
                userEntity.Password = user.Password;

                _unitOfWork.UserRepository.Update(userEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;

        }

        public async Task<ResponseDto> DeleteUser(int idUser)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.UserRepository.Delete(idUser);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente el usuario";
            else
                response.Message = "Hubo un error al eliminar el usuario, por favor vuelva a intentalo";

            return response;

        }

        public async Task<bool> InsertUser(InsertUserDto data)
        {
            ResponseDto result = new ResponseDto();

            if (Utils.ValidateEmail(data.Email))
            {
                if (_unitOfWork.UserRepository.FirstOrDefault(x => x.Email == data.Email) == null)
                {
                    RolUserEntity rolUser = new RolUserEntity()
                    {
                        IdUser = data.IdRol,
                        IdRol = (int)Enums.RolUser.Estandar,
                        UserEntity = new UserEntity()
                        {
                            Name = data.Name,
                            LastName = data.LastName,
                            Email = data.Email,
                            Password = data.Password,
                        }
                    };

                    _unitOfWork.RolUserRepository.Insert(rolUser);
                    return await _unitOfWork.Save() > 0;
                }
                else
                    result.Message = "Email ya se encuestra registrado, utilizar otro!";
            }
            else
                result.Message = "Usuario con Email Inválido";


            return Convert.ToBoolean(result);
        }



        public async Task<ResponseDto> Register(UserDto data)
        {
            ResponseDto result = new ResponseDto();

            if (Utils.ValidateEmail(data.UserName))
            {
                if (_unitOfWork.UserRepository.FirstOrDefault(x => x.Email == data.UserName) == null)
                {

                    RolUserEntity rolUser = new RolUserEntity()
                    {
                        IdRol = RolUser.Estandar.GetHashCode(),
                        UserEntity = new UserEntity()
                        {
                            Email = data.UserName,
                            LastName = data.LastName,
                            Name = data.Name,
                            Password = data.Password
                        }
                    };

                    _unitOfWork.RolUserRepository.Insert(rolUser);
                    result.IsSuccess = await _unitOfWork.Save() > 0;
                }
                else
                    result.Message = "Email ya se encuestra registrado, utilizar otro!";
            }
            else
                result.Message = "Usuario con Email Inválido";

            return result;
        }
        #endregion
    }
}