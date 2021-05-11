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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Desktop.ViewModels
{
    public class PrisonerViewModel : Screen, IHandle<UserPermisionEventModel>
    {
        private IEventAggregator _eventAggregator;
        private IPrisonerEndpoint _prisonerEndpoint;
        private BindingList<Prisoner> _allPrisoner;
        private string role;


        public PrisonerViewModel(IPrisonerEndpoint prisonerEndpoint, IEventAggregator eventAggregator)
        {
            _prisonerEndpoint = prisonerEndpoint;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
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
        public void Handle(UserPermisionEventModel message)
        {
            role = message._Roles;
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

        public async Task DeletePrisoner(Prisoner prisoner)
        {
            if (role == "Admin")
            {
                await _prisonerEndpoint.DeletePrisoner(prisoner.Id);
                await LoadPrisoners();
            }

        }
        public void DetailsOfThePrisoner(Prisoner prisoner)         
        {

            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(DetailsOfThePrisonerViewModel)));
            _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(prisoner));
            _eventAggregator.PublishOnUIThread(new UserPermisionEventModel(role));

        }


        public void AddPrisoner()
        {
            if (role == "Admin")
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(AddPrisonerViewModel)));
            }
        }
    }
}
