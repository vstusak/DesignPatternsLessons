using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacadePattern.Entities;

namespace FacadePattern
{
    public class WeatherService : IWeatherService
    {
        public int GetFahrenheit(City city, State state)
        {
            return 69;
        }
    }
}
