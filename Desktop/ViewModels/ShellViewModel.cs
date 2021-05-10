using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using Desktop.EventModels;
using Desktop.Model;
using Desktop.Views;

namespace Desktop.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEventModel>, IHandle<NextPageEventModel>, IHandle<UserPermisionEventModel>
    {
        //private LoginViewModel _loginViewModel;
        private IEventAggregator _eventAggregator;
        private SimpleContainer _simpleContainer;
        private string role;




        public ShellViewModel( IEventAggregator eventAggregator, SimpleContainer simpleContainer)
        {
            _eventAggregator = eventAggregator;
            _simpleContainer = simpleContainer;
            _eventAggregator.Subscribe(this);
            ActivateItem(_simpleContainer.GetInstance<LoginViewModel>());
             
        }

        public void Handle(LogOnEventModel message)
        {
            if(role == "Admin")
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(HomeViewModel)));
            }
            else
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(PrisonerViewModel)));
            }
            
        }
        public void Handle(NextPageEventModel nextPage)
        {
            var instance = IoC.GetInstance(nextPage._ViewModelType, null);
            ActivateItem(instance);
        }

        public void Handle(UserPermisionEventModel message)
        {
            role = message._Roles;
        }

        public void Home()
        {
            if (role == "Admin")
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(HomeViewModel)));
            }
            
        }
        public void Register()
        {
            if (role == "Admin")
            {
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(InvitationViewModel)));
            }            
        }
    }
}
