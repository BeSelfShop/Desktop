using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Api
{
   public interface IApiHelper
    {
        Task<UserAccess> Authenticate(string username, string password);
        HttpClient ApiClient { get; }
        void Authorized(string token);
    }
    
}
