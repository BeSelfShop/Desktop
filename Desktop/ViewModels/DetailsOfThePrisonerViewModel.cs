using Caliburn.Micro;
using Desktop.Api.Endpoints;
using Desktop.EventModels;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class DetailsOfThePrisonerViewModel : Screen, IHandle<SelectedPrisonerEventModel>
    {
        private IEventAggregator _eventAggregator;
        private IPassEndpoint _passEndpoint;
        private IPunishmentEndpoint _punishmentEndpoint;
        private Prisoner _getPrisoner;
        private Pass _getPass;
        private Punishment _getPunishment;


        public DetailsOfThePrisonerViewModel(IEventAggregator eventAggregator, IPassEndpoint passEndpoint, IPunishmentEndpoint punishmentEndpoint)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _passEndpoint = passEndpoint;
            _punishmentEndpoint = punishmentEndpoint;
        }

        private async Task LoadPrisonerDetails()
        {
            var getPunishment = await _punishmentEndpoint.SelectedPunishment(_getPrisoner.Id);
            GetPunishment = getPunishment;
            var getPass = await _passEndpoint.SelectedPass(_getPrisoner.Id);
            if (getPass.IdPrisoner != 0)
            {
                GetPass = getPass;
            }
            

        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadPrisonerDetails();

            
        }

        public void Handle(SelectedPrisonerEventModel message)
        {
            _getPrisoner = message.SelectedPrisoner;
        }

        public Prisoner GetPrisoner
        {
            get { return _getPrisoner; }
            set
            {
                _getPrisoner = value;
                NotifyOfPropertyChange(() => GetPrisoner);
            }
        }

        public Pass GetPass
        {
            get { return _getPass; }
            set
            {
                _getPass = value;
                NotifyOfPropertyChange(() => GetPass);
            }
        }

        public Punishment GetPunishment
        {
            get { return _getPunishment; }
            set
            {
                _getPunishment = value;
                NotifyOfPropertyChange(() => GetPunishment);
            }

        }

       


    }
}
