using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Model
{
    public class WeatherViewModel
    {
        public string LocationName { get; set; }
        public double Temperature { get; set; }
        public string Current { get; set; }
        public double Maximum { get; set; }
        public double Minimum { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }

    }
}
