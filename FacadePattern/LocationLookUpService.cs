using FacadePattern.Entities;

namespace FacadePattern
{
    public class LocationLookUpService
        : ILocationLookUpService, IAutoInstall
    {
        public City GetCity(string zip)
        {
            return new City();
        }

        public State GetState(string zip)
        {
            return new State();
        }

        public City GetCityByCoordinates(string longtitude, string latitude)
        {
            return new City();
        }

        public State GetStateByCapital(string capital)
        {
            return new State();
        }
    }
}