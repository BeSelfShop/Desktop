using Caliburn.Micro;
using Desktop.Api.Endpoints;
using Desktop.EventModels;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class AddIsolationViewModel : Screen, IHandle<SelectedPrisonerEventModel>
    {
        private IEventAggregator _eventAggregator;
        private IIsolationEndpoint _isolationEndpoint;
        private DateTime _startDate;
        private DateTime _endDate;
        private Prisoner _getPrisoner;

        public AddIsolationViewModel(IEventAggregator eventAggregator, IIsolationEndpoint isolationEndpoint)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _isolationEndpoint = isolationEndpoint;
        }

        public void Handle(SelectedPrisonerEventModel message)
        {
            _getPrisoner = message.SelectedPrisoner;
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

        public void AddPass()
        {
            Isolation isolation = new Isolation();
            isolation.IdPrisoner = _getPrisoner.Id;
            isolation.StartDate = StartDate;
            isolation.EndDate = EndDate;
            _isolationEndpoint.AddIsolation(isolation);
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(DetailsOfThePrisonerViewModel)));
            _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
        }
    }
}
