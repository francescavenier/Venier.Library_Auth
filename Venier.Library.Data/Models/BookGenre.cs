using System;
using System.Collections.Generic;
using System.Text;

namespace Venier.Library.Data.Models
{
    [Table("Genres")]
    public class BookGenre
    {
        [Key]
        public byte Id { get; set; }
        public string Description { get; set; }
    }
}
