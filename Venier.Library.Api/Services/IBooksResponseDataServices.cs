using System;
using System.Collections.Generic;
using System.Text;

namespace Venier.Library.Api.Services
{
    interface IBooksResponseDataServices
    {
        Task<IEnumerable<Doc>> GetResponse(string text);
    }
}
