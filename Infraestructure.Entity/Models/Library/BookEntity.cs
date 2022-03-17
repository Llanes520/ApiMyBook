using Infraestructure.Entity.Models.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Library
{
    [Table("Book", Schema ="Library")]
    public class BookEntity
    {
        [Key]
        public int IdBook { get; set; }  

        [MaxLength(100)]
        public string Titulo { get; set; }

        [MaxLength(500)]
        public string Sipnosis { get; set; }

        public int Num_Paginas { get; set; }


        [ForeignKey("TypeBookEntity")]
        public int IdTypeBook { get; set; }
        public TypeBookEntity TypeBookEntity { get; set; }

        [ForeignKey("EditorialEntity")]
        public int IdEditorial { get; set; }
        public EditorialEntity EditorialEntity { get; set; }

        public IEnumerable<Authors_has_BooksEntity> Authors_Has_BooksEntities { get; set; }
    }
}
