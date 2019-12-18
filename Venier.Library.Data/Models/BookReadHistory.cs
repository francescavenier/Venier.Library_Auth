using System;
using System.Collections.Generic;
using System.Text;

namespace Venier.Library.Data.Models
{
    [Table("ReadHistory")]
    public class BookReadHistory
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime ReadStart { get; set; }
        public DateTime? ReadEnd { get; set; }
        public string Notes { get; set; }
    }
}
