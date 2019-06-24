using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApi.Contract;

namespace WeatherApi.Interface
{
    public interface IWeatherService
    {
        Task<WeatherResponse> SearchWeather(string location);
    }
}