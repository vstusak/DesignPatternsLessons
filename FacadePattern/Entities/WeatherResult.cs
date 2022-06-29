using FacadePattern.Entities;

namespace FacadePattern
{
    public class WeatherResult
    {
        public City City { get; set; }
        public State State { get; set; }
        public int Fahrenheit { get; set; }
        public int Celsius { get; set; }
    }
}