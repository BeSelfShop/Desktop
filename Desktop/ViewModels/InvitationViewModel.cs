using Caliburn.Micro;
using Desktop.Api.Endpoints;
using Desktop.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class InvitationViewModel : Screen
    {
        private IRegistrationEndpoints _registrationEndpoint;
        private IEventAggregator _eventAggregator;
        private string _email = "";

        public InvitationViewModel(IRegistrationEndpoints registrationEndpoint, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _registrationEndpoint = registrationEndpoint;
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }
        public void AddUser()
        {
            _registrationEndpoint.SendEmial(_email);
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(HomeViewModel)));
        }

    }
}
