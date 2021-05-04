using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    public class Reason
    {
        public int Id { get; set; }
        public string ReasonName { get; set; }
        public virtual ICollection<Punishment> Punishments { get; set; }
    }
}
