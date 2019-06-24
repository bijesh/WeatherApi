using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApi.Interface
{
    public interface IWebApiClient
    {
        Task<HttpResponseMessage> GetAsync(Uri uri);
    }
}