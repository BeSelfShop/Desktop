using Caliburn.Micro;
using Desktop.EventModels;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class DetailsOfThePrisonerViewModel : Screen, IHandle<SelectedPrisonerEventModel>
    {
        private IEventAggregator _eventAggregator;
        private Prisoner _prisoner;
        public DetailsOfThePrisonerViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void Handle(SelectedPrisonerEventModel message)
        {
            _prisoner = message.SelectedPrisoner;
        }

        public Prisoner Prisoner
        {
            get { return _prisoner; }
            set
            {
                _prisoner = value;
                NotifyOfPropertyChange(() => Prisoner);
            }
        }

    }
}
