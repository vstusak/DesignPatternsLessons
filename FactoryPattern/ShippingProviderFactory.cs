using System;

namespace FactoryPattern
{
    public class ShippingProviderFactory : IShippingProviderFactory
    {
        public IShippingProvider Get(string DestinationCountry)
        {
            if (DestinationCountry == "CR")
            {
                var czechProvider = new CzechPostShippingProvider();
                return czechProvider;
            }
            else if (DestinationCountry == "SK")
            {
                var slovakProvider = new SlovakPostShippingProvider();
                return slovakProvider;
            }
            else
            {
                throw new Exception("Unknown destination country");
            }
        }
    }
}
