using FacadePattern.Entities;

namespace FacadePattern
{
    //public record WeatherFacadeResult(
    //    City City,
    //    State State,
    //    int TempF,
    //    int TempC);

    public class WeatherFacadeResult
    {
        public WeatherFacadeResult(City city, State state, int tempF, int tempC)
        {
            City = city;
            State = state;
            TempF = tempF;
            TempC = tempC;
        }

        public City City { get; set; }

        public State State { get; set; }

        public int TempF { get; set; }

        public int TempC { get; set; }

    }
}
