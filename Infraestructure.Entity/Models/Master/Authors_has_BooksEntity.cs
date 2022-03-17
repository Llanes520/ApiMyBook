using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Master
{
    public class Authors_has_BooksEntity
    {
        public int Id { get; set; }

        [ForeignKey("AuthorsEntity")]
        public int Id_Authors { get; set; }
        public AuthorsEntity AuthorsEntity { get; set; } 
        
        [ForeignKey("BookEntity")]
        public int Id_Books { get; set; }
        public BookEntity BookEntity { get; set; }
    }
}
