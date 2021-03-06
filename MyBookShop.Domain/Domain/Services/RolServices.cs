using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBookShop.Domain.Domain.Services.IServices
{
    public class RolServices : IRolServices
    {
        private readonly IUnitOfWork _uniOfWork;

        public RolServices(IUnitOfWork uniOfWork)
        {
            _uniOfWork = uniOfWork;
        }

        public List<RolEntity> GetAll() => _uniOfWork.RolRepository.GetAll().ToList();

    }
}
