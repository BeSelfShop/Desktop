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
        private IApiHelper _apiHelper;
        public ReasonEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
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

        public async Task<Reason> SelectedReason(int idReason)
        {
            using(HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Reason/"+ idReason))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<Reason>();
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
