using Caliburn.Micro;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.EventModels
{
    public class SelectedPunishmentEventModel 
    {
        private Punishment _selectedPunishment;
        public SelectedPunishmentEventModel(Punishment selectedPunishment)
        {
            _selectedPunishment = selectedPunishment;
        }
        public Punishment SelectedPunishment
        {
            get { return _selectedPunishment; }
        }
    }
}
