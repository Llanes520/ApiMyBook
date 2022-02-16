using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Microsoft.Extensions.DependencyInjection;
using MyBook.Domain.Domain.Services;
using MyBook.Domain.Domain.Services.IServices;
using MyBookShop.Domain.Domain.Services;
using MyBookShop.Domain.Domain.Services.Iservices;
using MyBookShop.Domain.Domain.Services.IServices;

namespace ApiBook.Handler
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {
            // Repository await UnitofWork parameter ctor explicit
            services.AddScoped<UnitOfWork, UnitOfWork>();


            // Infrastructure
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<SeedDb>();

            //Domain
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IRolServices, RolServices>();
            services.AddTransient<IBookService, BookServices>();
            services.AddTransient<IEditorialServices, EditorialServices>();
        }
    }
}
