using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Venier.Library.Data.Models;

namespace Venier.Library.Data.Repositories
{
    public class BooksGenresRepository : IBooksGenresRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;


        public BooksGenresRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Delete(int id)
        {
            byte parseId = (byte)id;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Delete(new BookGenre() { Id = parseId });
            }
        }

        public BookGenre Get(int id)
        {
            byte parseId = (byte)id;
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<BookGenre>(parseId);
            }
        }

        public IEnumerable<BookGenre> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<BookGenre>();
            }
        }

        public IEnumerable<Book> GetBooksByGenre(byte genre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Book>(@"
                SELECT [Id]
                      ,[Title]
                      ,[Author]
                      ,[Description]
                      ,[CreationDate]
                      ,[GenreId]
                      ,[PublishedDate]
                      ,[IsRead]
                      ,[DateLastUpdate]
                      ,[ImageUrl]
                      ,[Rate]
                  FROM [ITS-IOT].[dbo].[Books]
                WHERE GenreId = @Genre", new { Genre = genre });
            }
        }

        public BookGenre GetGenre(byte genreId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<BookGenre>(@"
                SELECT [Id]
                      ,[Description]
                  FROM [dbo].[Genres]
                WHERE Id = @Genre", new { Genre = genreId });
            }
        }

        public void Insert(BookGenre model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert<BookGenre>(model);
            }
        }

        public void Update(BookGenre model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Update<BookGenre>(model);
            }
        }
    }
}
