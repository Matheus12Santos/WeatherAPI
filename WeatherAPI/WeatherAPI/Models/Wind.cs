using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class Wind
    {
        public required float Speed { get; set; }
        public required int Deg { get; set; }
        public required float Gust { get; set; }
    }
}
