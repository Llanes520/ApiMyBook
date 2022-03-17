using Infraestructure.Entity.Models.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Security
{
    public class AuthorsEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public IEnumerable<Authors_has_BooksEntity> Authors_Has_BooksEntities { get; set; } 
    }
}
