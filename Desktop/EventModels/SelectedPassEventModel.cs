using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.EventModels
{
    public class SelectedPassEventModel
    {
        private Pass _selectedPass;
        public SelectedPassEventModel(Pass selectedPass)
        {
            _selectedPass = selectedPass;
        }
        public Pass SelectedPass
        {
            get { return _selectedPass; }
        }
    }
}
