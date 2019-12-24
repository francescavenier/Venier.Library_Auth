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
        public Book Book;
        public string InputISBN;
        public void OnGet(string isbn)
        {
            InputISBN = isbn;
            var details = GetDetails(isbn).GetAwaiter().GetResult();
        }
    }
}