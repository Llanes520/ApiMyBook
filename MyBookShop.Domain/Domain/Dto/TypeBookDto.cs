using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBook.Domain.Domain.Dto
{
    public class TypeBookDto
    {
        [Key]
        public int IdTypeBook { get; set; }

        [MaxLength(100)]
        public string TypeBook { get; set; }
    }
}
