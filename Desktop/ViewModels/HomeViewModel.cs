using Caliburn.Micro;
using Desktop.Api;
using Desktop.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class HomeViewModel : Screen , IHandle<UserPermisionEventModel>
    {
        private IEventAggregator _eventAggregator;
        private string role;

        public HomeViewModel( IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(UserPermisionEventModel message)
        {
            role = message._Roles;
        }

        public void Logger()
        {
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(LoggerViewModel)));
            _eventAggregator.PublishOnUIThread(new UserPermisionEventModel(role));
        }
        public void PCells()
        {
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(CellViewModel)));
            _eventAggregator.PublishOnUIThread(new UserPermisionEventModel(role));
        }
        public void Prisoner()
        {
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(PrisonerViewModel)));
            _eventAggregator.PublishOnUIThread(new UserPermisionEventModel(role));
        }
    }
}
