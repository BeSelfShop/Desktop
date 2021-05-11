using Caliburn.Micro;
using Desktop.Api;
using Desktop.Api.Endpoints;
using Desktop.EventModels;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop.ViewModels
{
    public class AddPrisonerViewModel : Screen
    {
        private IEventAggregator _eventAggregator;
        private IPrisonerEndpoint _prisonerEndpoint;
        private ICellEndpoint _cellEndpoint;
        private BindingList<Cell> _cells;
        private string _name = "";
        private string _forname = "";
        private string _pesel = "";
        private string _addres = "";
        private int _behavior ;
        private Cell _cell;


        public AddPrisonerViewModel(IEventAggregator eventAggregator,IPrisonerEndpoint prisonerEndpoint, ICellEndpoint cellEndpoint)
        {
            _eventAggregator = eventAggregator;
            _prisonerEndpoint = prisonerEndpoint;
            _cellEndpoint = cellEndpoint;
        }

        private async Task Load()
        {
            var cellList = await _cellEndpoint.AllCell();
            Cells = new BindingList<Cell>(cellList);
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await Load();
        }




        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanAddPrisoner);
            }

        }

        public string Forname
        {
            get { return _forname; }
            set
            {
                _forname = value;
                NotifyOfPropertyChange(() => Forname);
                NotifyOfPropertyChange(() => CanAddPrisoner);
            }
        }

        public string Pesel
        {
            get { return _pesel; }
            set
            {
                _pesel = value;
                NotifyOfPropertyChange(() => Pesel);
                NotifyOfPropertyChange(() => CanAddPrisoner);
            }

        }

        public string Addres
        {
            get { return _addres; }
            set
            {
                _addres = value;
                NotifyOfPropertyChange(() => Addres);
                NotifyOfPropertyChange(() => CanAddPrisoner);
            }

        }

        public int Behavior
        {
            get { return _behavior; }
            set
            {
                _behavior = value;
                NotifyOfPropertyChange(() => Behavior);
                NotifyOfPropertyChange(() => CanAddPrisoner);
            }

        }

        public BindingList<Cell> Cells
        {
            get { return _cells; }
            set
            {
                _cells = value;
                NotifyOfPropertyChange(() => Cells);
                NotifyOfPropertyChange(() => CanAddPrisoner);
            }

        }

        public Cell SelectedCell
        {
            get { return _cell; }
            set
            {
                _cell = value;
                NotifyOfPropertyChange(() => SelectedCell);
                NotifyOfPropertyChange(() => CanAddPrisoner);

            }
        }
        public bool CanAddPrisoner
        {
            get
            {
                bool output = false;

                if ((Name.Length > 0) && (Forname.Length > 0) && (Pesel.Length > 0) && (Addres.Length > 0) && (Behavior > 0) && (SelectedCell.BedsCount != 0))
                {
                    output = true;
                }

                return output;

            }

        }


        public void AddPrisoner()
        {
            Prisoner prisoner = new Prisoner();
            prisoner.Name = Name;
            prisoner.Forname = Forname;
            prisoner.Pesel = Pesel;
            prisoner.Address = Addres;
            prisoner.Pass = false;
            prisoner.Behavior = Behavior;
            prisoner.Isolated = false;
            prisoner.IdCell = SelectedCell.Id;
            _prisonerEndpoint.AddPrisoner(prisoner);
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(PrisonerViewModel)));
        }
    }
}
