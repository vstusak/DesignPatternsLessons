using Factory;

var country = DestinationCountry.CZ;

var delivery = new DeliveryInfo
{
    Name = "Peter",
    Surname = "Parker",
    City = "New York",
    Street = "Ceska",
    StreetNumber = "10",
    PostalCode = "60200",
    Country = country,
};

var labelProviderFactory = new LabelProviderFactory();

var provider = labelProviderFactory.GetLabelProvider(country);

var result = provider.RenderLabel(delivery);

Console.WriteLine(result);

