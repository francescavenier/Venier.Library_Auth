using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Venier.Library.Api.Models;

namespace Venier.Library.Api.Services
{
    class BooksResponseDataServices
    {
        public async Task<IEnumerable<Doc>> GetResponse(string text)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://openlibrary.org/search.json?q=" + text);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();

            var obj = await JsonSerializer.DeserializeAsync<BooksResponse>(stream);
            return obj.docs;
        }
    }
}
