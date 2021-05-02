using Caliburn.Micro;
using Desktop.Api;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Desktop.ViewModels
{
    public class AddPrisonerViewModel : Screen
    {
        private IPrisonerEndpoint _prisonerEndpoint;
        private Prisoner _Prisoner;
        private string _name;
        private string _forname;
        private string _pesel;
        private string _addres;
        private bool _pass;
        private int _behavior;
        private bool _isolated;
        private int _idCell;

        Button button = new Button();


        public AddPrisonerViewModel(IPrisonerEndpoint prisonerEndpoint)
        {
            _prisonerEndpoint = prisonerEndpoint;
        }

        private async Task LoadPrisoners()
        {
            var prisonersList = await _prisonerEndpoint.AllPrisoner();
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadPrisoners();
        }




        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }

        }

        public string Forname
        {
            get { return _forname; }
            set
            {
                _forname = value;
                NotifyOfPropertyChange(() => Forname);
            }
        }

        public string Pesel
        {
            get { return _pesel; }
            set
            {
                _pesel = value;
                NotifyOfPropertyChange(() => Pesel);

            }

        }

        public string Addres
        {
            get { return _addres; }
            set
            {
                _addres = value;
                NotifyOfPropertyChange(() => Addres);

            }

        }

        public bool Pass
        {
            get { return _pass; }
            set
            {
                _pass = value;
                NotifyOfPropertyChange(() => Pass);

            }

        }

        public int Behavior
        {
            get { return _behavior; }
            set
            {
                _behavior = value;
                NotifyOfPropertyChange(() => Behavior);

            }

        }

        public bool Isolated
        {
            get { return _isolated; }
            set
            {
                _isolated = value;
                NotifyOfPropertyChange(() => Isolated);

            }

        }

        public int IdCell
        {
            get { return _idCell; }
            set
            {
                _idCell = value;
                NotifyOfPropertyChange(() => IdCell);

            }

        }
    }
}
