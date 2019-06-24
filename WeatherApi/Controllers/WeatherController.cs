using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Interface;
using WeatherApi.Model;
using WeatherApi.Services;
using WeatherApi.Utilities;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
       private IWeatherService _weatherService;
       private IWeatherResultViewModelBuilder _weatherResultViewModelBuilder;
       public WeatherController(IWeatherService weatherService, IWeatherResultViewModelBuilder weatherResultViewModelBuilder)
       {
           _weatherService = weatherService;
           _weatherResultViewModelBuilder = weatherResultViewModelBuilder;
       }

        // GET api/weather/5
        [HttpGet("{location}")]
        [ProducesResponseType(typeof(WeatherViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<WeatherViewModel>> Get(string location)
        {
                var weatherResponse = await _weatherService.SearchWeather(location);
                // TODO : check got a valid response 
                // TODO : handle exception 
                var weatherViewModel = _weatherResultViewModelBuilder.Build(weatherResponse);
                return weatherViewModel;

        }
    }
}