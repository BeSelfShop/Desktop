using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    class InviteCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public int IdPrison { get; set; }
    }
}
