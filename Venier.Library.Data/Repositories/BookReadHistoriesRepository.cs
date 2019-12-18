﻿using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Venier.Library.Data.Models;

namespace Venier.Library.Data.Repositories
{
    public class BookReadHistoriesRepository : IBookReadHistoriesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;


        public BookReadHistoriesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Delete(new BookReadHistory() { Id = id });
            }
        }

        public BookReadHistory Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<BookReadHistory>(id);
            }
        }

        public IEnumerable<BookReadHistory> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<BookReadHistory>();
            }
        }

        public IEnumerable<BookReadHistory> GetByBook(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<BookReadHistory>(@"
                SELECT [Id]
                      ,[BookId]
                      ,[ReadStart]
                      ,[ReadEnd]
                      ,[Notes]
                  FROM [dbo].[ReadHistories]
                WHERE BookId = @Book", new { Book = bookId });
            }
        }

        public void Insert(BookReadHistory model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Insert(model);
            }
        }

        public void Update(BookReadHistory model)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Update(model);
            }
        }
    }
}
