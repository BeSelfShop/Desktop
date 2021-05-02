using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    public class UserAccess
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
        public string Roles { get; set; }
        
    }
}
