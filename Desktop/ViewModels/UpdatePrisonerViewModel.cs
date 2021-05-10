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
    public class UpdatePrisonerViewModel : Screen, IHandle<SelectedPrisonerEventModel>
    {
        private IEventAggregator _eventAggregator;
        private IPrisonerEndpoint _prisonerEndpoint;
        private ICellEndpoint _cellEndpoint;
        private BindingList<Cell> _cells;
        private string _name;
        private string _forname;
        private string _pesel;
        private string _address;
        private int _behavior;
        private Cell _cell;
        private Prisoner _prisoner;


        public UpdatePrisonerViewModel(IEventAggregator eventAggregator, IPrisonerEndpoint prisonerEndpoint, ICellEndpoint cellEndpoint)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _prisonerEndpoint = prisonerEndpoint;
            _cellEndpoint = cellEndpoint;
        }

        private async Task Load()
        {
            var cell = await _cellEndpoint.SelectedCell(_prisoner.IdCell);
            SelectedCell = cell;
            var cellList = await _cellEndpoint.AllCell();
            Cells = new BindingList<Cell>(cellList); 
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await Load();
        }

        public void Handle(SelectedPrisonerEventModel message)
        {
            _prisoner = message.SelectedPrisoner;
        }


        public string PrisonerName
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => PrisonerName);
            }

        }

        public string PrisonerForname
        {
            get { return _forname; }
            set
            {
                _forname = value;
                NotifyOfPropertyChange(() => PrisonerForname);
            }
        }

        public string PrisonerPesel
        {
            get { return _pesel; }
            set
            {
                _pesel = value;
                NotifyOfPropertyChange(() => PrisonerPesel);

            }

        }

        public string PrisonerAddress
        {
            get { return _address; }
            set
            {
                _address = value;
                NotifyOfPropertyChange(() => PrisonerAddress);

            }

        }

        public int PrisonerBehavior
        {
            get { return _behavior; }
            set
            {
                _behavior = value;
                NotifyOfPropertyChange(() => PrisonerBehavior);

            }

        }

        public BindingList<Cell> Cells
        {
            get { return _cells; }
            set
            {
                _cells = value;
                NotifyOfPropertyChange(() => Cells);

            }

        }

        public Cell SelectedCell
        {
            get { return _cell; }
            set
            {
                _cell = value;
                NotifyOfPropertyChange(() => SelectedCell);

            }
        }
        
        public Prisoner GetPrisoner
        {
            get { return _prisoner; }
            set
            {
                _prisoner = value;
                NotifyOfPropertyChange(() => GetPrisoner);

            }
        }


        public void AddPrisoner()
        {
            Prisoner prisoner = new Prisoner();
            prisoner = _prisoner;
            prisoner.Name = PrisonerName;
            prisoner.Forname = PrisonerForname;
            prisoner.Pesel = PrisonerPesel;
            prisoner.Address = PrisonerAddress;
            prisoner.Behavior = PrisonerBehavior;
            prisoner.IdCell = SelectedCell.Id;
            _prisonerEndpoint.UpdatePrisoner(prisoner.Id, prisoner);
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(DetailsOfThePrisonerViewModel)));
            _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_prisoner));
        }
    }
}
