using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Api.Endpoints
{
    public interface ILoggerEndpoint
    {
        Task<List<Logger>> AllLogs();
    }
}
