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
    public class CellTypeEndpoint : ICellTypeEndpoint
    {
        private IApiHelper _apiHelper;
        public CellTypeEndpoint(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public async Task<List<CellType>> AllCellType()
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.ApiClient.GetAsync("api/CellType"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<CellType>>();
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
