using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApi.Contract;
using WeatherApi.Interface;

namespace WeatherApi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWebApiClient _webApiClient;
        public WeatherService(IWebApiClient webApiClient)
        {
            _webApiClient = webApiClient;
        }

        public async Task<WeatherResponse> SearchWeather(string location)
        {
            //TODO Catch and Log Exception 
            //TODO Monitor and Log Performance 
            //TODO: Read the URL and Headers values from config
            Uri uri = new Uri($"http://samples.openweathermap.org/data/2.5/weather?q={ location }&appid=b6907d289e10d714a6e88b30761fae22");
            //TODO: check the url is valid

            var response = await _webApiClient.GetAsync(uri);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsAsync<WeatherResponse>();
                return result;
            }
            return null;
        }

    }
}
