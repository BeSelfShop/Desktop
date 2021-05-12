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
    public class DetailsOfThePrisonerViewModel : Screen, IHandle<SelectedPrisonerEventModel>, IHandle<UserPermisionEventModel>
    {
        private IEventAggregator _eventAggregator;
        private IPassEndpoint _passEndpoint;
        private IPunishmentEndpoint _punishmentEndpoint;
        private IReasonEndpoint _reasonEndpoint;
        private IIsolationEndpoint _isolationEndpoint;
        private Prisoner _getPrisoner;
        private Pass _getPass;
        private Punishment _getPunishment;
        private Reason _getReason;
        private Isolation _getIsolation;
        private bool _endDateCancel = false;
        private bool __liferyCancel = false;
        private string role;


        public DetailsOfThePrisonerViewModel(IEventAggregator eventAggregator, IPassEndpoint passEndpoint, IPunishmentEndpoint punishmentEndpoint,
            IReasonEndpoint reasonEndpoint, IIsolationEndpoint isolationEndpoint)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _passEndpoint = passEndpoint;
            _punishmentEndpoint = punishmentEndpoint;
            _reasonEndpoint = reasonEndpoint;
            _isolationEndpoint = isolationEndpoint;
        }

        private async Task LoadPrisonerDetails()
        {
            var getPunishment = await _punishmentEndpoint.SelectedPunishment(_getPrisoner.Id);
            GetPunishment = getPunishment;
            if(getPunishment != null)
            {
                EndingSentence();
                var getReason = await _reasonEndpoint.SelectedReason(_getPunishment.IdReason);
                GetReason = getReason;
            }           
            
            var getPass = await _passEndpoint.SelectedPass(_getPrisoner.Id);
            if ((getPass != null))
            {
                GetPass = getPass;
            }

            var getIsolation = await _isolationEndpoint.SelectedIsolation(_getPrisoner.Id);
            if ((getIsolation != null))
            {
                GetIsolation = getIsolation;
            }
        }
        private void EndingSentence()
        {
            if (_getPunishment.Lifery)
            {
                LiferyCancel = true;
            }
            else
            {
                EndDateCancel = true;
            }
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadPrisonerDetails();

            
        }

        public void Handle(SelectedPrisonerEventModel message)
        {
            _getPrisoner = message.SelectedPrisoner;
        }
        public void Handle(UserPermisionEventModel message)
        {
            role = message._Roles;
        }

        public Prisoner GetPrisoner
        {
            get { return _getPrisoner; }
            set
            {
                _getPrisoner = value;
                NotifyOfPropertyChange(() => GetPrisoner);
            }
        }
        public Reason GetReason
        {
            get { return _getReason; }
            set
            {
                _getReason = value;
                NotifyOfPropertyChange(() => GetReason);
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

        public Punishment GetPunishment
        {
            get { return _getPunishment; }
            set
            {
                _getPunishment = value;
                NotifyOfPropertyChange(() => GetPunishment);
            }

        }
        public Isolation GetIsolation
        {
            get { return _getIsolation; }
            set
            {
                _getIsolation = value;
                NotifyOfPropertyChange(() => GetIsolation);
            }
        }
        public bool EndDateCancel
        {
            get { return _endDateCancel; }
            set
            {
                _endDateCancel = value;
                NotifyOfPropertyChange(() => EndDateCancel);
            }
        }

        public bool LiferyCancel
        {
            get { return __liferyCancel; }
            set
            {
                __liferyCancel = value;
                NotifyOfPropertyChange(() => LiferyCancel);
            }
        }

        public void UpdatePrisoner()
        {
            if (role == "Admin")
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(UpdatePrisonerViewModel)));
                _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
            }

        }
        public void AddPunishment()
        {
            if ((role == "Admin")&& (GetPunishment == null))
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(AddPunishmentViewModel)));
                _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
            }

        }
        public void UpdatePunishment()
        {
            if ((role == "Admin")&&(GetPunishment != null))
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(UpdatePunishmentViewModel)));
                _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
                _eventAggregator.PublishOnUIThread(new SelectedPunishmentEventModel(_getPunishment));
            }

        }
        
        public void UpdatePass()
        {
            if (GetPass != null)
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(UpdatePassViewModel)));
                _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
                _eventAggregator.PublishOnUIThread(new SelectedPassEventModel(_getPass));
            }
        }
        public void AddPass()
        {
            if (GetPass == null)
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(AddPassViewModel)));
                _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
            }

        }
        public void DeletePass()
        {
            if (GetPass == null)
            {
                _passEndpoint.DeletePass(GetPass.Id);
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(DetailsOfThePrisonerViewModel)));
                _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
            }
        }
        public void AddIsolation()
        {
            if(GetIsolation == null)
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(AddIsolationViewModel)));
                _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
            }
        }
        public void DeleteIsolation()
        {
            if (GetIsolation != null)
            {
                _isolationEndpoint.DeleteIsolation(GetIsolation.Id);
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(DetailsOfThePrisonerViewModel)));
                _eventAggregator.PublishOnUIThread(new SelectedPrisonerEventModel(_getPrisoner));
            }

        }


    }
}
