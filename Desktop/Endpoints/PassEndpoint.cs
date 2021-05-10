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
    public class PassEndpoint : IPassEndpoint
    {
        private IApiHelper _apiHelper;

        public PassEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task AddPass(Pass pass)
        {
            var json = JsonConvert.SerializeObject(pass);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync("api/Pass", stringContent);
        }

        public async Task<List<Pass>> AllPass()
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Pass"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<Pass>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task DeletePass(int idPass)
        {
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.DeleteAsync("api/Pass/" + idPass);
        }

        public async Task<Pass> SelectedPass(int idPrisoner)
        {
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Pass/" + idPrisoner);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsAsync<Pass>();
                return result;
            }
            else
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }
        }
        public async Task UpdatePass(int idPass, Pass pass)
        {
            var json = JsonConvert.SerializeObject(pass);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PutAsync("api/Prisoner/" + idPass, stringContent);
        }
    }
}
