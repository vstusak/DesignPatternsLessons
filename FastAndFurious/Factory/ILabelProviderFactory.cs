using Factory;

public interface ILabelProviderFactory
{
    ILabelProvider GetLabelProvider(DestinationCountry destinationCountry);
}