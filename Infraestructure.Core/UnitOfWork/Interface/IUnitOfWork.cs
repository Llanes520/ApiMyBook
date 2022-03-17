using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity.Models;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Entity.Models.Security;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<UserEntity> UserRepository { get; }
        IRepository<RolEntity> RolRepository { get; }
        IRepository<RolUserEntity> RolUserRepository { get; }
        IRepository<PermissionEntity> PermissionRepository { get; }
        IRepository<TypePermissionEntity> TypePermissionRepository { get; }
        IRepository<RolPermissionEntity> RolesPermissionRepository { get; }
        IRepository<AuthorsEntity> AuthorsRepository { get; }


        IRepository<BookEntity> BooksRepository { get; }
        IRepository<EditorialEntity> EditorialRepository { get; }


        IRepository<TypeBookEntity> TypeBookRepository { get; }
        IRepository<Authors_has_BooksEntity> Authors_has_BooksRepository { get; }










        void Dispose();

        Task<int> Save();
    }
}
