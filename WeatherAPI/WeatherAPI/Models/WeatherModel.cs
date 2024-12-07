using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class WeatherModel
    {
        [JsonPropertyName("id")]
        public int WeatherId;

        [JsonPropertyName("main")]
        public string Clime;

        [JsonPropertyName("description")]
        public string ClimeDescription;

        [JsonPropertyName("icon")]
        public string ClimeIcon;
    }
}
