using Common.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBook.Domain.Domain.Services.IServices
{
    public interface IPermissionServices
    {
        bool ValidatePermissionByUser(Enums.Permission permission, int idUser);
    }
}
