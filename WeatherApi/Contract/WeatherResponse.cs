using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApi.Contract
{
    public class WeatherResponse
    {
        [JsonProperty("main")]
        public Main main { get; set; }

        [JsonProperty("sys")]
        public Sys sys { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

