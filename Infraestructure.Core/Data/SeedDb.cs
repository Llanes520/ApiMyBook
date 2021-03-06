using Common.Utils.Enums;
using Infraestructure.Entity.Models;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.Data
{
    public class SeedDb
    {
        #region Attributhes
        private readonly DataContext _context; 
        #endregion

        #region Builder
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        #endregion

        /*
        Despues de ejecutar la data semilla, crear un usuario y libros en la Db
        Nota: me falto el editorial
        */

        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckUserAsync();
            await CheckTypePermissionAsync();
            await CheckPermissionAsync();
            await CheckRolAsync();
            await CheckRolPermissonAsync();
            await CheckRolUserAsync();
            await CheckTypeBookEntityAsync();
            await CheckEditorialEntityAsync();
            await CheckAuthorsEntityAsync();
        }


        private async Task CheckTypePermissionAsync()
        {
            if (!_context.TypePermissionEntity.Any())
            {
                _context.TypePermissionEntity.AddRange(new List<TypePermissionEntity>
                {
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        TypePermission="Usuarios"
                    },
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        TypePermission="Roles"
                    },
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        TypePermission="Permisos"
                    },
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        TypePermission="Estados"
                    },
                    new TypePermissionEntity
                    {
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        TypePermission="Libros"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPermissionAsync()
        {
            if (!_context.PermissionEntity.Any())
            {
                _context.PermissionEntity.AddRange(new List<PermissionEntity>
                {
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Crear Usuarios",
                        Description="Crear usuarios en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Actualizar Usuarios",
                        Description="Actualizar datos de un usuario en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Eliminar Usuarios",
                        Description="Eliminar un usuairo del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Consultar Usuarios",
                        Description="Consulta todos los usuarios"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Actualizar Roles",
                        Description="Actualizar datos de un Roles en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Consultar Roles",
                        Description="Consultar Roles del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Actualizar Permisos",
                        Description="Actualizar datos de un Permiso en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Consultar Permisos",
                        Description="Consultar Permisos del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.DenegarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Denegar Permisos Rol",
                        Description="Denegar permisos a un rol del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Consultar Estado",
                        Description="Consultar los estados del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarEstado,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Actualizar Estados",
                        Description="Actualizar los estados del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Crear libros",
                        Description="Crear la información de los libros"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Actualizar libros",
                        Description="Actualizar la información de los libros"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Eliminar libros",
                        Description="Eliminar la información de los libros"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Consultar libros",
                        Description="Consultar la información de los libros"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRolAsync()
        {
            if (!_context.RolEntity.Any())
            {
                _context.RolEntity.AddRange(new List<RolEntity>
                {
                    new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Administrador,
                        Rol="Administrador"
                    },
                     new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Estandar,
                        Rol="Estandar"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRolPermissonAsync()
        {
            if (!_context.RolPermissionEntity.Where(x => x.IdRol == (int)Enums.RolUser.Administrador).Any())
            {
                var rolesPermisosAdmin = _context.PermissionEntity.Select(x => new RolPermissionEntity
                {
                    IdRol = (int)Enums.RolUser.Administrador,
                    IdPermission = x.IdPermission
                }).ToList();

                _context.RolPermissionEntity.AddRange(rolesPermisosAdmin);


                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckUserAsync()
        {
            if (!_context.UserEntity.Any())
            {
                _context.UserEntity.AddRange(new List<UserEntity>
                {
                    new UserEntity
                    {
                        Name ="Pablo",
                        LastName="Rodriguez",
                        Email="Pablo@gmail.com",
                        Password="123456"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRolUserAsync()
        {
            if (!_context.RolUserEntity.Any())
            {
                _context.RolUserEntity.AddRange(new List<RolUserEntity>
                {
                    new RolUserEntity
                    {
                        IdRol = (int)Enums.RolUser.Administrador,
                        IdUser = (int)Enums.User.idUSer,
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckTypeBookEntityAsync()
        {
            if (!_context.TypeBookEntity.Any())
            {
                _context.TypeBookEntity.AddRange(new List<TypeBookEntity>
                {
                    new TypeBookEntity
                    {
                        TypeBook = "Revista"
                    },
                    new TypeBookEntity
                    {
                        TypeBook = "Libro"
                    },
                    new TypeBookEntity
                    {
                        TypeBook = "Comic"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckEditorialEntityAsync()
        {
            if (!_context.EditorialEntity.Any())
            {
                _context.EditorialEntity.AddRange(new List<EditorialEntity>
                {
                    new EditorialEntity
                    {
                        Nombre = "Periodistico",
                        Sede = "Bogota"
                    },
                    new EditorialEntity
                    {
                        Nombre = "Noticia",
                        Sede = "Cali"
                    },
                    new EditorialEntity
                    {
                        Nombre = "Historieta",
                        Sede = "Medellin"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }
        
        private async Task CheckAuthorsEntityAsync()
        {
            if (!_context.AuthorsEntities.Any())
            {
                _context.AuthorsEntities.AddRange(new List<AuthorsEntity>
                {
                    new AuthorsEntity
                    {
                        Nombre = "Pablo",
                        Apellidos = "Rodrigez"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}