using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WeatherApi.Interface
{
    public interface IHttpRequestBuilder
    {
        HttpRequestMessage GetHttpRequestMessage(Uri uri, HttpMethod httpMethod);
    }
}