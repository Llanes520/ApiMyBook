using MyBook.Domain.Domain.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookShop.Domain.Domain.Dto
{
    public class UserDto : LoginDto
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(100)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        public string Email { get; set; }



        //[DataType(DataType.Password)]
        //[Display(Name = "Confirmar Contraseña")]
        //[Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        //public string ConfirmPassword { get; set; }


    }
}
