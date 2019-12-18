using System;
using System.Collections.Generic;
using System.Text;
using Venier.Library.Data.Models;

namespace Venier.Library.Data
{
    public interface IBooksRepository
        :IRepository<Book,int>
    {
        
    }

        /*
        public interface IBooksRepository
        {
            Book Get(int id);
            IEnumerable<Book> GetAll();
            void Insert(Book model);
            void Update(Book model);
            void Delete(int id);

        }
        */
    }
