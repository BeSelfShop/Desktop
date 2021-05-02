using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    public class Cell
    {
        public int Id { get; set; }
        public string CellNumber { get; set; }
        public int BedsCount { get; set; }
        public int IdPrison { get; set; } 
        public int OccupiedBeds { get; set; }
        public int IdCellType { get; set; }
    }
}
