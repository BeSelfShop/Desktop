using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Desktop.HttpGrabber
{
    public class ApiHelper
    {
        private HttpClient httpClient { get; set; }
        private void ApiClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(api);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
