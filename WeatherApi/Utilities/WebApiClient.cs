using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApi.Interface;

namespace WeatherApi.Utilities
{
    public class WebApiClient : IWebApiClient
    {
        private System.Net.Http.HttpClient _client;
        private IHttpRequestBuilder _httpRequestBuilder;

        public WebApiClient(IHttpRequestBuilder httpRequestBuilder)
        {
            if (_client == null)
            {
                _client = new System.Net.Http.HttpClient();
            }

            _httpRequestBuilder = httpRequestBuilder;
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            var request = _httpRequestBuilder.GetHttpRequestMessage(uri, HttpMethod.Get);
            var response = await _client.SendAsync(request);
            return response;

        }
    }
}
