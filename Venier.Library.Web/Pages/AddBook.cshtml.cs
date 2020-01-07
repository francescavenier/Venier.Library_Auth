using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Venier.Library.Data.Models;
using Venier.Library.Api.Services;
using Venier.Library.Api.Models;
using Venier.Library.Data;

namespace Venier.Library.Web
{
    public class DetailsModel : PageModel
    {
        private readonly IBookDetailsResponseDataServices _bookDetailsResponseDataServices;
        private readonly IBooksRepository _bookRepository;

        public DetailsModel(IBookDetailsResponseDataServices bookDetailsResponseDataServices, IBooksRepository booksRepository)
        {
            _bookDetailsResponseDataServices = bookDetailsResponseDataServices;
            _bookRepository = booksRepository;
        }

        public Book Book;
        public string InputISBN;
        public string Info_url;

        public void OnGet(string isbn)
        {
            InputISBN = isbn;
            var details = _bookDetailsResponseDataServices.GetDetails(isbn).GetAwaiter().GetResult();
            Info_url = details.info_url;
            var description = "Unfortunately the description of this book is not available.";
            string author = (details.details.authors[0].name == null ? "Unknown" : details.details.authors[0].name);

            Book = new Book
            {
                Title = details.details.title,
                Author = author,
                Description = description,
                CreationDate = DateTime.Now
            };

            _bookRepository.Insert(Book);

        }
    }
}


