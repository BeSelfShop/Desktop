using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Hepler
{
   public interface IApiHelper
    {
        Task<UserAccess> Authenticate(string username, string password);
    }
}
