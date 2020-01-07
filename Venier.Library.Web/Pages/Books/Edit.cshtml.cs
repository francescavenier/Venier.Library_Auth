using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public EditBook editBook { get; set; }
        public Book Book { get; set; }
        
        public IEnumerable<BookReadHistory> History { get; set; }

        public class EditBook
        {
            [Display(Name = "Title")]
            [Required]
            public string Title { get; set; }

            [Display(Name = "Author")]
            public string Author { get; set; }

            [Display(Name = "Description")]
            public string Description { get; set; }

            [Display(Name = "Creation Date")]
            public DateTime CreationDate { get; set; }

            [Display(Name = "Genre")]
            public byte? GenreId { get; set; }

            [Display(Name = "Published Date")]
            public DateTime? PublishedDate { get; set; }

            [Display(Name = "Is read?")]
            public bool IsRead { get; set; }

            [Display(Name = "Date of last update")]
            public DateTime? DateLastUpdate { get; set; }
        }

        public void OnGet(int id)
        {
            Book = _booksRepository.Get(id);
            this.editBook = new EditBook {
                Author = Book.Author,
                Title = Book.Title,
                Description = Book.Description,
                CreationDate = Book.CreationDate,
                GenreId = Book.GenreId,
                PublishedDate = Book.PublishedDate,
                IsRead = Book.IsRead,
                DateLastUpdate = Book.DateLastUpdate
            };
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                Book = new Book { 
                    Author = editBook.Author,
                    Title = editBook.Title,
                    Description = editBook.Description,
                    CreationDate = editBook.CreationDate,
                    GenreId = editBook.GenreId,
                    PublishedDate = editBook.PublishedDate,
                    IsRead = editBook.IsRead,
                    DateLastUpdate = DateTime.Now };
                //Book.DateLastUpdate = DateTime.Now;
                _booksRepository.Update(Book);
                return RedirectToPage("/Index"); // da modificare il redirect
            }
            return Page();
        }
    }
}