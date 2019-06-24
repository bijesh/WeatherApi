using System.Net.Http;

namespace WeatherApi.Interface
{
    public interface IHttpClientBuilder
    {
       HttpClient GetHttpClient();
    }
}