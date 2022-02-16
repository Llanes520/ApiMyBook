using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBook.Domain.Domain.Dto.Books
{
    public class InsertBookDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(300)]
        [Display(Name = "Descripcion")]
        public string Descriptin { get; set; }

        [Required(ErrorMessage = "El nombre del autor es requerido")]
        [MaxLength(100)]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de preaprobado es requerida")]
        [Display(Name = "Fecha preaprobado")]
        public DateTime DatePreRealease { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de aprobado es requerida")]
        [Display(Name = "Fecha aprobado")]
        public DateTime? DateRealease { get; set; }

        [Required(ErrorMessage = "El typo de libro es requerido es requerida")]
        public int IdTypeBook { get; set; }

        public int IdState { get; set; }
         
        public int IdEditorial { get; set; }
    }
}
