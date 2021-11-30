using FacadePattern.Entities;

namespace FacadePattern
{
    public interface ILocationLookUpService
    {
        City GetCity(string zip);
        City GetCityByCoordinates(string longtitude, string latitude);
        State GetState(string zip);
        State GetStateByCapital(string capital);
    }
}