using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacadePattern.Entities;

namespace FacadePattern
{
    public class LocationLookupService : ILocationLookupService
    {
        public City GetCity(string zipCode)
        {
            return new City();
        }

        public State GetState(string zipCode)
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
