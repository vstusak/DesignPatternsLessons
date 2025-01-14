using Factory;

public class LabelProviderFactory : ILabelProviderFactory
{
    private readonly Dictionary<DestinationCountry, ILabelProvider> _providers = new();

    public ILabelProvider GetLabelProvider(DestinationCountry destinationCountry)
    {
        if (_providers.TryGetValue(destinationCountry, out var provider))
        {
            return provider;
        }

        provider = destinationCountry switch
        {
            DestinationCountry.CZ => new CzLabelProvider(),
            DestinationCountry.SK => new SkLabelProvider(),
            DestinationCountry.GB => new GbLabelProvider(),
            _ => throw new NotSupportedException(),
        };

        _providers.Add(destinationCountry, provider);

        return provider;
    }
}