using WeatherApi.Contract;
using WeatherApi.Interface;
using WeatherApi.Model;

namespace WeatherApi.ViewModelBuilder
{
    public class WeatherResultViewModelBuilder : IWeatherResultViewModelBuilder
    {
        public WeatherViewModel Build(WeatherResponse weatherResponse)
        {
            return new WeatherViewModel()
            {
                LocationName = weatherResponse.Name,
                Humidity = weatherResponse.main.Humidity,
                Maximum = weatherResponse.main.TempMax,
                Minimum = weatherResponse.main.TempMin,
                Pressure = weatherResponse.main.Pressure,
                Temperature = weatherResponse.main.Temp,
                Sunrise = weatherResponse.sys.Sunrise,
                Sunset = weatherResponse.sys.Sunset,
            };
        }
    }
}