using Desktop.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Hepler
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient apiClient;

        public ApiHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UserAccess> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", password),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)

            });

            using(HttpResponseMessage responseMessage = await apiClient.PostAsync("api/Authentication/login", data))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    try
                    {
                        
                        var result = await responseMessage.Content.ReadAsAsync<UserAccess>();

                        return result;
                    }
                    catch(Exception e)
                    {
                        var gds = e.Message;
                        return null;
                    }
                    
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }

            }
        }
    }
}
