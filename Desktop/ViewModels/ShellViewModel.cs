using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using Desktop.EventModels;
using Desktop.Views;

namespace Desktop.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEventModel>, IHandle<NextPageEventModel>
    {
        //private LoginViewModel _loginViewModel;
        private IEventAggregator _eventAggregator;
        private SimpleContainer _simpleContainer;
        private HomeViewModel _homeViewModel;




        public ShellViewModel( IEventAggregator eventAggregator, SimpleContainer simpleContainer, HomeViewModel homeViewModel)
        {
            _eventAggregator = eventAggregator;
            _simpleContainer = simpleContainer;
            _eventAggregator.Subscribe(this);
            ActivateItem(_simpleContainer.GetInstance<LoginViewModel>());
            _homeViewModel = homeViewModel;
            
             
        }

        public void Handle(LogOnEventModel message)
        {
            
                ActivateItem(_homeViewModel);           
        }

        

        public void Handle(NextPageEventModel nextPage)
        {
            var instance = IoC.GetInstance(nextPage._ViewModelType, null);
            ActivateItem(instance);

        }
    }
}
