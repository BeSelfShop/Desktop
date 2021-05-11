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
    public class CellEndpoint : ICellEndpoint
    {
        private IApiHelper _apiHelper;
        public CellEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<Cell>> AllCell()
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/PCells"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<Cell>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }

            }
        }
        public async Task DeleteCell(int idCell)
        {
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.DeleteAsync("api/PCells/" + idCell);

        }
        public async Task AddCell(Cell cell)
        {
            var json = JsonConvert.SerializeObject(cell);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PostAsync("api/PCells", stringContent);
        }
        public async Task<Cell> SelectedCell(int idCell)
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/PCells/"+idCell))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<Cell>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }

            }
        }
        public async Task UpdateCell(int idCell, Cell cell)
        {
            var json = JsonConvert.SerializeObject(cell);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await _apiHelper.ApiClient.PutAsync("api/PCells/" + idCell, stringContent);
        }
    }
}
