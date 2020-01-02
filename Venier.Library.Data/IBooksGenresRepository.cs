using System;
using System.Collections.Generic;
using System.Text;
using Venier.Library.Data.Models;

namespace Venier.Library.Data
{
    public interface IBooksGenresRepository
         : IRepository<BookGenre, int>
    {
        IEnumerable<Book> GetBooksByGenre(byte genre);

        BookGenre GetGenre(byte genre);
    }
}
