using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class Weather
    {
        public int WeatherId { get; set; }
        public required string Clime { get; set; }
        public required string ClimeDescription { get; set; }
        public required string ClimeIcon { get; set; }
    }
}
