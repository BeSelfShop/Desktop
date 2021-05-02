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
    public class HomeViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        public HomeViewModel( IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        public void CellType()
        {
            
        }
        public void Pass()
        {
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(PassViewModel)));
        }
        public void Prisoner()
        {
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(PrisonerViewModel)));                       
        }
    }
}
