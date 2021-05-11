using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.EventModels
{
    public class SelectedCellEventModel
    {
        private Cell _selectedCell;
        public SelectedCellEventModel(Cell selectedCell)
        {
            _selectedCell = selectedCell;
        }
        public Cell SelectedCell
        {
            get { return _selectedCell; }
        }
    }
}
