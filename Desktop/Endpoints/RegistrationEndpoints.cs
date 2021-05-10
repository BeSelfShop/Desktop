using Desktop.Api;
using Desktop.Api.Endpoints;
using Desktop.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Endpoints
{
    public class RegistrationEndpoints : IRegistrationEndpoints
    {
        private IApiHelper _apiHelper;
        public RegistrationEndpoints(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task AddEmployer(Registration registration)
        {
            var json = JsonConvert.SerializeObject(registration);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync("api/Authentication/register", stringContent);
        }

        public async Task SendEmial(string email)
        {
            var json = JsonConvert.SerializeObject(email);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync("api/RegisterMail/send", stringContent);
        }
    }
}
