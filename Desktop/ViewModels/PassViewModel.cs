using Caliburn.Micro;
using Desktop.Api;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class PassViewModel : Screen
    {
        private IPassEndpoint _passEndpoint;
        private BindingList<Pass> _allPass;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _idPrisoner;

        public PassViewModel(IPassEndpoint passEndpoint)
        {
            _passEndpoint = passEndpoint;
        }
        private async Task LoadPass()
        {
            var passList = await _passEndpoint.AllPass();
            AllPass = new BindingList<Pass>(passList);
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadPass();

        }

        public BindingList<Pass> AllPass
        {
            get { return _allPass;  }
            set
            {
                _allPass = value;
                NotifyOfPropertyChange(() => AllPass);
            }
        }


        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                NotifyOfPropertyChange(() => StartDate);
               
            }

        }


        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                NotifyOfPropertyChange(() => EndDate);
            }

        }

        public int IdPrisoner
        {
            get { return _idPrisoner; }
            set
            {
                _idPrisoner = value;
                NotifyOfPropertyChange(() => IdPrisoner);
            }

        }

    }
}
