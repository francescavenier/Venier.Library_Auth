using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Venier.Library.Data.Models;
using Venier.Library.Api.Services;

namespace Venier.Library.Web
{
    public class DetailsModel : PageModel
    {
        private readonly IBookDetailsResponseDataServices _bookDetailsResponseDataServices;

        public DetailsModel(IBookDetailsResponseDataServices bookDetailsResponseDataServices)
        {
            _bookDetailsResponseDataServices = bookDetailsResponseDataServices;
        }



        public Book Book;
        public string InputISBN;
        public void OnGet(string isbn)
        {
            InputISBN = isbn;
            var details = _bookDetailsResponseDataServices.GetDetails(isbn).GetAwaiter().GetResult();
            DateTime pubDate = DateTime.Parse("01/01/"+details.details.publish_date);

            Book = new Book
            {
                Author = "Unknown",
                Title = details.details.title,
                Description = details.preview,
                PublishedDate = pubDate
            };
        }
    }
}