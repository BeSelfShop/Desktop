using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    class Logger
    {
        public int Id { get; set; }
        public DateTime LogData { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int IdPrison { get; set; }
    }
}
