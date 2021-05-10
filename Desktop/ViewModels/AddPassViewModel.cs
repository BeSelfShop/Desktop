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
    public class AddPassViewModel : Screen, IHandle<SelectedPrisonerEventModel>
    {
        private IEventAggregator _eventAggregator;
        private IPassEndpoint _passEndpoint;
        private DateTime _startDate;
        private DateTime _endDate;
        private Prisoner _getPrisoner;

        public AddPassViewModel(IEventAggregator eventAggregator, IPassEndpoint passEndpoint)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _passEndpoint = passEndpoint;
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
            Pass pass = new Pass();
            pass.IdPrisoner = _getPrisoner.Id;
            pass.StartDate = StartDate;
            pass.EndDate = EndDate;
            _passEndpoint.AddPass(pass);
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(DetailsOfThePrisonerViewModel)));
            _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
        }
    }
}
