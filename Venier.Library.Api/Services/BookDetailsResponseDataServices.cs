using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Venier.Library.Api.Models;

namespace Venier.Library.Api.Services
{
    public class BookDetailsResponseDataServices
    {
        private static async Task<BookDetailsResponse> GetDetails(string isbn)
        {
            var url = $"https://openlibrary.org/api/books?bibkeys=ISBN:{isbn}&jscmd=details&format=json";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var stringResult = await client.GetStringAsync(url);

            var obj = JObject.Parse(stringResult);
            var details = obj[$"ISBN:{isbn}"];

            return details.ToObject<BookDetailsResponse>();
        }
    }
}
