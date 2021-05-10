using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Helper;
using Desktop.Api;
using Desktop.EventModels;
using System.Windows.Navigation;

namespace Desktop.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName = "";
        private string _password = "";
        private IApiHelper _apiHelper;
        private IEventAggregator _eventAggregator;

        public LoginViewModel(IApiHelper apiHelper, IEventAggregator eventAggregator)
        {
            _apiHelper = apiHelper;
            _eventAggregator = eventAggregator;
        }

        public string UserName
        {
            get { return _userName; }
            set {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);

            }

        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
                
            }

        }

        public bool CanLogin
        {
            get
            {
                bool output = false;

                if ((UserName.Length > 0) && (Password.Length > 0))
                {
                    output = true;
                }

                return output;

            }
            
        }

        public async Task Login()
        {
            try
            {

                var result = await _apiHelper.Authenticate(UserName, Password);
                _apiHelper.Authorized(result.Token);
                _eventAggregator.PublishOnUIThread(new LogOnEventModel());
                


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Register()
        {
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(RegistrationViewModel)));
        }
            
        
     }
}

