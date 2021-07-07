namespace FactoryPattern
{
    public interface IShippingProviderFactory
    {
        IShippingProvider Get(string DestinationCountry);
    }
}