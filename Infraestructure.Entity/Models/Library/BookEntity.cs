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
        public string Name { get; set; }

        [MaxLength(300)]
        public string Descriptin { get; set; }

        [MaxLength(100)]
        public string Author { get; set; }

        public DateTime DatePreRealease { get; set; }

        public DateTime? DateRealease { get; set; }


        [ForeignKey("TypeBookEntity")]
        public int IdTypeBook { get; set; }
        public TypeBookEntity TypeBookEntity { get; set; }

        [ForeignKey("StateEntity")]
        public int IdState { get; set; }
        public StateEntity StateEntity { get; set; }

        [ForeignKey("EditorialEntity")]
        public int IdEditorial { get; set; }
        public EditorialEntity EditorialEntity { get; set; }
    }
}
