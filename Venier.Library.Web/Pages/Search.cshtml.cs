using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Venier.Library.Api.Models;
using Venier.Library.Api.Services;

namespace Venier.Library.Web
{
    public class SearchModel : PageModel
    {
        public IEnumerable<Doc> Books;

        private readonly IBooksResponseDataServices _bookResponseDataService;

        public SearchModel(IEnumerable<Doc> books, IBooksResponseDataServices bookResponseDataService)
        {
            Books = books;
            _bookResponseDataService = bookResponseDataService;
        }

        public async Task OnPost()
        {
            string text = Request.Form["testo"];

            Books = await _bookResponseDataService.GetResponse(text);
        }
    }
}