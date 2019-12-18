using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Venier.Library.Data.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public byte? GenreId { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateLastUpdate { get; set; }
        public string ImageUrl { get; set; }
        public byte? Rate { get; set; }
    }
}
