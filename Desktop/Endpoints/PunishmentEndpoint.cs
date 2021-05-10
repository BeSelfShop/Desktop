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
    public class PunishmentEndpoint : IPunishmentEndpoint
    {
        private IApiHelper _apiHelper;
        public PunishmentEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task AddPunishment(Punishment punishment)
        {
            var json = JsonConvert.SerializeObject(punishment);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync("api/Punishment", stringContent);
        }

        public async Task<Punishment> SelectedPunishment(int idPunishment)
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/Punishment/"+ idPunishment))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<Punishment>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task DeletePunishment(int idPunishment)
        {
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.DeleteAsync("api/Punishment/" + idPunishment);
        }
        public async Task UpdatePunishment(int idPunishment, Punishment punishment)
        {
            var json = JsonConvert.SerializeObject(punishment);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PutAsync("api/Punishment/" + idPunishment, stringContent);
        }
    }
}
