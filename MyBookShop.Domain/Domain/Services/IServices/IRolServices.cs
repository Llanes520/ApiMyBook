using Infraestructure.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookShop.Domain.Domain.Services.IServices
{
    public interface IRolServices
    {
        List<RolEntity> GetAll();
    }
}
