using Desktop.Api;
using Desktop.Api.Endpoints;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Endpoints
{
    public class LoggerEndpoint : ILoggerEndpoint
    {
        private IApiHelper _apiHelper;
        public LoggerEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<Logger>> AllLogs()
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Logger"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<Logger>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }

            }
        }
    }
}
