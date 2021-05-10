using Caliburn.Micro;
using Desktop.Api.Endpoints;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class LoggerViewModel : Screen
    {
        private ILoggerEndpoint _loggerEndpoint;
        private BindingList<Logger> _allLogs;


        public LoggerViewModel(ILoggerEndpoint loggerEndpoint)
        {
            _loggerEndpoint = loggerEndpoint;
        }

        private async Task LoadCells()
        {
            var logsList = await _loggerEndpoint.AllLogs();
            AllLogs = new BindingList<Logger>(logsList);
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadCells();
        }

        public BindingList<Logger> AllLogs
        {
            get { return _allLogs; }
            set
            {
                _allLogs = value;
                NotifyOfPropertyChange(() => AllLogs);
            }
        }
    }
}
