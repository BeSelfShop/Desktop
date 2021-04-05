using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    public class UserAccess
    {
        public string token { get; set; }
        public string expiration { get; set; }
        public string roles { get; set; }
        
    }
}
