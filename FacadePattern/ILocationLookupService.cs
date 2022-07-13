using FacadePattern.Entities;

namespace FacadePattern;

public interface ILocationLookupService
{
    City GetCity(string zipCode);
    State GetState(string zipCode);
    City GetCityByCoordinates(string longtitude, string latitude);
    State GetStateByCapital(string capital);
}