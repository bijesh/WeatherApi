using Newtonsoft.Json;

namespace WeatherApi.Contract
{
    public class Sys
    {
       
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }
}