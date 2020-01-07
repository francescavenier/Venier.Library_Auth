using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Venier.Library.Data;
using Venier.Library.Data.Models;

namespace Venier.Library.Web.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IBookReadHistoriesRepository _bookReadHistoriesRepository;
        private readonly IBooksGenresRepository _booksGenresRepository;


        public DetailsModel(IBooksRepository booksRepository, IBookReadHistoriesRepository bookReadHistoriesRepository, IBooksGenresRepository booksGenresRepository)
        {
            _booksRepository = booksRepository;
            _bookReadHistoriesRepository = bookReadHistoriesRepository;
            _booksGenresRepository = booksGenresRepository;
        }
        public Book Book { get; set; }
        public BookGenre Genre { get; set; }

        public string PublishedDate { get; set; }
        public string CreationDate { get; set; }

        public IEnumerable<BookReadHistory> History { get; set; }
        public void OnGet(int id)
        {
            Book = _booksRepository.Get(id);
            DateTime PubDate = ((Book.PublishedDate != null) ? (DateTime)Book.PublishedDate : DateTime.MinValue);
            PublishedDate = PubDate.Date.ToString("dd MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            DateTime CreDate = Book.CreationDate;
            CreationDate = CreDate.Date.ToString("dd MMM yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            if (Book.GenreId != null)
            {
                byte Id = (byte)Book.GenreId;
                Genre = _booksGenresRepository.GetGenre(Id);
            }
           
            History = _bookReadHistoriesRepository.GetByBook(id);
        }
    }
}