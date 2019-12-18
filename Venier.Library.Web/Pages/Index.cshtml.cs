using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Venier.Library.Data;
using Venier.Library.Data.Models;

namespace Venier.Library.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBooksRepository _booksRepository;

        public IEnumerable<Book> Books { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBooksRepository booksRepository)
        {
            _logger = logger;
            _booksRepository = booksRepository;
        }

        public void OnGet()
        {
            Books = _booksRepository.GetAll();
        }
    }
}
