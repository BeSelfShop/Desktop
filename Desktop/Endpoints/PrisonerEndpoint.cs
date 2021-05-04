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
    public class PrisonerEndpoint : IPrisonerEndpoint
    {
        private IApiHelper _apiHelper;
        public PrisonerEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<Prisoner>> AllPrisoner()
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Prisoner"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<Prisoner>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }

            }
        }
        public async Task DeletePrisoner(int idPrisoner)
        {
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.DeleteAsync("api/Prisoner/"+idPrisoner);

        }
        public async Task AddPrisoner(Prisoner prisoner)
        {
            var json = JsonConvert.SerializeObject(prisoner);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync("api/Prisoner", stringContent);
        }

        public async Task<Prisoner> SelectedPrisoner(int idPrisoner)
        {
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Prisoner/" + idPrisoner);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsAsync<Prisoner>();
                return result;
            }
            else
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }
        }
       public async Task UpdatePrisoner(int idPrisoner, Prisoner prisoner)
        {
            var json = JsonConvert.SerializeObject(prisoner);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PutAsync("api/Prisoner/" + idPrisoner, stringContent);
        }
    }
}
