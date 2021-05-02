using Caliburn.Micro;
using Desktop.Api;
using Desktop.EventModels;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Desktop.ViewModels
{
    public class PrisonerViewModel : Screen 
    {
        private IEventAggregator _eventAggregator;
        private IPrisonerEndpoint _prisonerEndpoint;
        private BindingList<Prisoner> _allPrisoner;
        private int _id;
        private string _name;
        private string _forname;
        Button button = new Button();


        public PrisonerViewModel(IPrisonerEndpoint prisonerEndpoint, IEventAggregator eventAggregator)
        {
            _prisonerEndpoint = prisonerEndpoint;
            _eventAggregator = eventAggregator;
        }

        private async Task LoadPrisoners()
        {
            var prisonersList = await _prisonerEndpoint.AllPrisoner();
            AllPrisoner = new BindingList<Prisoner>(prisonersList);
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadPrisoners();
        }

        public BindingList<Prisoner> AllPrisoner
        {
            get { return _allPrisoner; }
            set
            {
                _allPrisoner = value;
                NotifyOfPropertyChange(() => AllPrisoner);               
            }
        }


        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);

            }

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

        public async Task DeletePrisoner(Prisoner prisoner)
        {

            await _prisonerEndpoint.DeletePrisoner(prisoner.Id);
            await  LoadPrisoners();

        }
        public void DetailsOfThePrisoner(Prisoner prisoner)
        {
            
        }
        public void AddPrisoner()
        {
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(AddPrisonerViewModel)));
        }


    }
}
