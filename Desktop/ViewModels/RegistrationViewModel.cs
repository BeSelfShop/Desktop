using Caliburn.Micro;
using Desktop.Api.Endpoints;
using Desktop.EventModels;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class RegistrationViewModel : Screen
    {
        private IRegistrationEndpoints _registrationEndpoint;
        private IEventAggregator _eventAggregator;
        private string _userName = "";
        private string _email = "";
        private string _password = "";
        private string _name = "";
        private string _forname = "";
        private string _inviteCode = "";

        public RegistrationViewModel(IRegistrationEndpoints registrationEndpoint, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _registrationEndpoint = registrationEndpoint;
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }

        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);

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

        public string InviteCode
        {
            get { return _inviteCode; }
            set
            {
                _inviteCode = value;
                NotifyOfPropertyChange(() => InviteCode);

            }

        }
        public bool CanAddUser
        {
            get
            {
                bool output = false;

                if ((UserName.Length > 0) && (Password.Length > 0) && (Email.Length > 0) && (Name.Length > 0) && (Forname.Length > 0) && (InviteCode.Length > 0))
                {
                    output = true;
                }

                return output;

            }

        }


        public void AddUser()
        {
            try
            {
                Registration registration = new Registration();
                registration.UserName = UserName;
                registration.Password = Password;
                registration.Name = Name;
                registration.Forname = Forname;
                registration.Email = Email;
                registration.InviteCode = InviteCode;
                _registrationEndpoint.AddEmployer(registration);
                _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(LoginViewModel)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

