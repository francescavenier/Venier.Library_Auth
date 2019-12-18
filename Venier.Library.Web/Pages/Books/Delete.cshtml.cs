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
    public class DeleteModel : PageModel
    {
        private readonly IBooksRepository _booksRepository;


        public DeleteModel(IBooksRepository booksRepository, IBookReadHistoriesRepository bookReadHistoriesRepository)
        {
            _booksRepository = booksRepository;
        }
        public Book Book { get; set; }
        public PageResult OnGet(int id)
        {
            _booksRepository.Delete(id);
            return Page();
        }
    }
}