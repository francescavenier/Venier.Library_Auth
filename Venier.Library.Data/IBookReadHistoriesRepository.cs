using System;
using System.Collections.Generic;
using System.Text;
using Venier.Library.Data.Models;

namespace Venier.Library.Data
{
    public interface IBookReadHistoriesRepository
        : IRepository<BookReadHistory, int>
    {
        IEnumerable<BookReadHistory> GetByBook(int bookId);
    }
}
