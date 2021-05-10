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
    public class IsolationEndpoint : IIsolationEndpoint
    {
        private IApiHelper _apiHelper;

        public IsolationEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task AddIsolation(Isolation isolation)
        {
            var json = JsonConvert.SerializeObject(isolation);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync("api/Isolation", stringContent);
        }

        public async Task<List<Isolation>> AllIsolation()
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Isolation"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<Isolation>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task DeleteIsolation(int idIsolation)
        {
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.DeleteAsync("api/Isolation/" + idIsolation);
        }

        public async Task<Isolation> SelectedIsolation(int idPrisoner)
        {
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Isolation/" + idPrisoner);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsAsync<Isolation>();
                return result;
            }
            else
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }
        }
        public async Task UpdatePass(int idIsolation, Isolation isolation)
        {
            var json = JsonConvert.SerializeObject(isolation);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PutAsync("api/Isolation/" + idIsolation, stringContent);
        }
    }
}
