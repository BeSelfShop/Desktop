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
    public class ReasonEndpoint : IReasonEndpoint
    {
        private ApiHelper _apiHelper;
        public ReasonEndpoint(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task AddReason(Reason reason)
        {
            var json = JsonConvert.SerializeObject(reason);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync("api/Reason", stringContent);
        }

        public async Task<List<Reason>> AllReason()
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Reason"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<Reason>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task DeleteReason(int idReason)
        {
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.DeleteAsync("api/Reason/"+idReason);
        }
    }
}
