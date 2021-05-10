using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.EventModels
{
    public class UserPermisionEventModel
    {
        public readonly string _Roles;

        public UserPermisionEventModel(string Roles)
        {
            _Roles = Roles;
        }
    }
}
