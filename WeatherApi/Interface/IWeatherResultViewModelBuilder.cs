using System.Collections.Generic;
using WeatherApi.Contract;
using WeatherApi.Model;

namespace WeatherApi.Interface
{
    public interface IWeatherResultViewModelBuilder
    {
        WeatherViewModel Build(WeatherResponse weatherResponse);
    }
}