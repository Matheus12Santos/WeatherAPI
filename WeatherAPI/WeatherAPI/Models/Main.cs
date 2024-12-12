using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class Main
    {
        public required float Temp { get; set; }
        public required int Pressure { get; set; }
        public required int Humidity { get; set; }
    }
}
