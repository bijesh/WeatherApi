using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherApi.Interface;

namespace WeatherApi.Utilities
{
    public class HttpRequestBuilder : IHttpRequestBuilder
    {
        public const string ContentTypeValue = "application/json";

        public HttpRequestMessage GetHttpRequestMessage(Uri uri, HttpMethod httpMethod)
        {
            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = uri,
                Method = httpMethod
            };
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentTypeValue));
            return httpRequestMessage;
        }
    }
}
