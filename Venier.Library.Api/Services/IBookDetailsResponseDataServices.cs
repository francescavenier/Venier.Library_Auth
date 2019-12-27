using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Venier.Library.Api.Models;

namespace Venier.Library.Api.Services
{
    public interface IBookDetailsResponseDataServices
    {
         Task<BookDetailsResponse> GetDetails(string isbn);
    }
}
