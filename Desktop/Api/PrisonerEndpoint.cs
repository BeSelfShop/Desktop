using Desktop.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Api
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
            var data = new StringContent(JsonConvert.SerializeObject(prisoner));
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync("api/Prisoner", data);
        }
    }
}
