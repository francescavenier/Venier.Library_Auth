using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Venier.Library.Data;
using Venier.Library.Data.Models;

namespace Venier.Library.Web
{
    public class EditModel : PageModel
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IBookReadHistoriesRepository _bookReadHistoriesRepository;
        
        public EditModel(IBooksRepository booksRepository, IBookReadHistoriesRepository bookReadHistoriesRepository)
        {
            _booksRepository = booksRepository;
            _bookReadHistoriesRepository = bookReadHistoriesRepository;
        }
        
        [BindProperty]
        public Book Book { get; set; }
        public IEnumerable<BookReadHistory> History { get; set; }

        public void OnGet(int id)
        {
            Book = _booksRepository.Get(id);
        }

        public IActionResult OnPost(int id)
        {
                _booksRepository.Update(Book);
                return RedirectToPage("/Index"); // da modificare il redirect

        }
    }
}