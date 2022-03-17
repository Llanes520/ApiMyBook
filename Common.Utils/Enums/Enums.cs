using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Enums
{
    public class Enums
    {
        public enum TypeState
        {
            //Usuario
            EstadoUsuario = 1,

            EstadoLibros = 2,
        }

        public enum State
        {
            //Usuario
            UsuarioActivo = 1,

            UsuarioInactivo = 2,
            UsuarioSuspendido = 3,

            //Libros
            Preaprobado = 4,
            Aprobado = 5,
        }

        public enum TypePermission
        {
            Usuarios = 1,
            Roles = 2,
            Permisos = 3,
            Estados = 5,
            Libros = 6,
        }

        public enum Permission
        {
            //Usuarios
            CrearUsuarios = 1,

            ActualizarUsuarios = 2,
            EliminarUsuarios = 3,
            ConsultarUsuarios = 4,
            
            //Roles
            ActualizarRoles = 5,
            ConsultarRoles = 6,
            
            //Permisos
            ActualizarPermisos = 7,
            ConsultarPermisos = 8,
            DenegarPermisos = 9,
            
            //Estados
            ConsultarEstados = 10,
            ActualizarEstado = 11,
            
            //Libros
            CrearLibros = 12,
            ActualizarLibros = 13,
            EliminarLibros = 14,
            ConsultarLibros = 15,
        }

        public enum RolUser
        {
            Administrador = 1,
            Estandar = 3,
        }

        public enum User
        {
            idUSer = 1,
        }

        public enum TypeBook
        {
            Revista = 1,
            Libro = 2,
            Comic = 3,
        }
        public enum Editorial
        {
            Periodistico = 1,
            Noticia = 2,
            Historieta = 3,
        }

    }
}
