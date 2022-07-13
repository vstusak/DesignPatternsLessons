using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class TemperatureConverterService : ITemperatureConverterService
    {
        public int ToCelsius(int f)
        {
            double celsius = (5.0 / 9.0) * (f - 32);
            return (int)celsius;
        }

        public int ToFahrenheit(int c)
        {
            double fahrenheit = c * (1.8 + 32);
            return (int)fahrenheit;
        }
}
}
