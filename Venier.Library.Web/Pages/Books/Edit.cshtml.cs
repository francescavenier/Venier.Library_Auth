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

        string Title { get; set; }
        string Author { get; set; }
        string Description { get; set; }
        DateTime CreationDate { get; set; }
        byte? GenreId { get; set; }
        DateTime? PublishedDate { get; set; }
        bool IsRead { get; set; }
        DateTime? DateLastUpdate { get; set; }
                     
        public void OnGet(int id)
        {
            Book = _booksRepository.Get(id);
            Title = Book.Title;
            Author = Book.Author;
            Description = Book.Description;
            CreationDate = Book.CreationDate;
            GenreId = Book.GenreId;
            PublishedDate = Book.PublishedDate;
            IsRead = Book.IsRead;
            DateLastUpdate = Book.DateLastUpdate;
        }

        public IActionResult OnPost(int id)
        {
            Book = new Book { Author = Author, DateLastUpdate = DateTime.Now}; 
            //Book.DateLastUpdate = DateTime.Now;
            _booksRepository.Update(Book);
            return RedirectToPage("/Index"); // da modificare il redirect

        }
    }
}