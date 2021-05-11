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
    public class UpdatePassViewModel : Screen, IHandle<SelectedPrisonerEventModel>, IHandle<SelectedPassEventModel>
    {
        private IEventAggregator _eventAggregator;
        private IPassEndpoint _passEndpoint;
        private DateTime _startDate;
        private DateTime _endDate;
        private Prisoner prisoner;
        private Pass _getPass;

        public UpdatePassViewModel(IEventAggregator eventAggregator, IPassEndpoint passEndpoint)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _passEndpoint = passEndpoint;
        }

        public void Handle(SelectedPrisonerEventModel message)
        {
            prisoner = message.SelectedPrisoner;
        }
        public void Handle(SelectedPassEventModel message)
        {
            _getPass = message.SelectedPass;
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
        public Pass GetPass
        {
            get { return _getPass; }
            set
            {
                _getPass = value;
                NotifyOfPropertyChange(() => GetPass);
            }
        }

        public void AddPass()
        {
            Pass pass;
            pass = _getPass;
            if(EndDate != null)
            {
                pass.EndDate = EndDate;
            }
            _passEndpoint.UpdatePass(pass.Id,pass);
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(DetailsOfThePrisonerViewModel)));
            _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(prisoner));
        }
    }
}

