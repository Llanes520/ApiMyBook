using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBook.Domain.Domain.Dto.Editoriales
{
    public class EditorialDto
    {
        [Key]
        public int IdEditorial { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        public string Sede { get; set; }
    }
}
