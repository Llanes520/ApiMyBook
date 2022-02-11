using Infraestructure.Entity.Models.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Master
{
    [Table("TypeBook", Schema ="Master")]
    public class TypeBookEntity
    {
        [Key]
        public int IdTypeBook { get; set; }

        [MaxLength(100)]
        public string TypeBook { get; set; }

        public BookEntity bookEntity { get; set; }
    }
}
