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
        public Main? main { get; set; }
        public Weather? weather { get; set; }
        public Wind? wind { get; set; }
    }
}
