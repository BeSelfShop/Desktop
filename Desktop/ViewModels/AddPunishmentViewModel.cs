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
    public class AddPunishmentViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private BindingList<Reason> _reasons;
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _lifery;
        private IReasonEndpoint _reasonEndpoint;
        private IPunishmentEndpoint _punishmentEndpoint;
        private Reason _selectedReason;

        public AddPunishmentViewModel(IEventAggregator eventAggregator, IReasonEndpoint reasonEndpoint, IPunishmentEndpoint punishmentEndpoint)
        {
            _eventAggregator = eventAggregator;
            _reasonEndpoint = reasonEndpoint;
            _punishmentEndpoint = punishmentEndpoint;
        }

        private async Task Load()
        {
            var reasonList = await _reasonEndpoint.AllReason();
            Reasons = new BindingList<Reason>(reasonList);
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await Load();
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

        public bool Lifery
        {
            get { return _lifery; }
            set
            {
                _lifery = value;
                NotifyOfPropertyChange(() => Lifery);

            }

        }

        public BindingList<Reason> Reasons
        {
            get { return _reasons; }
            set
            {
                _reasons = value;
                NotifyOfPropertyChange(() => Reasons);

            }

        }

        public Reason SelectedReason
        {
            get { return _selectedReason; }
            set
            {
                _selectedReason = value;
                NotifyOfPropertyChange(() => SelectedReason);

            }

        }

        public void AddPunishment()
        {
            Punishment punishment = new Punishment();
            punishment.StartDate = StartDate;
            punishment.EndDate = EndDate;
            punishment.Lifery = Lifery;
            punishment.IdReason = SelectedReason.Id;
            _punishmentEndpoint.AddPunishment(punishment);
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(DetailsOfThePrisonerViewModel)));
        }
    }

}

