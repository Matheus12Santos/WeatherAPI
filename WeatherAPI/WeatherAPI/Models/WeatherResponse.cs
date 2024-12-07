using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("temp")]
        public string Temperature;

        [JsonPropertyName("humidity")]
        public string Humidity;

        [JsonPropertyName("wind_speed")]
        public string Wind;

        [JsonPropertyName("sunrise")]
        public string Sunrise;

        [JsonPropertyName("sunset")]
        public string Sunset;

        public List<WeatherModel> WeatherModel { get; set; }
    }
}
