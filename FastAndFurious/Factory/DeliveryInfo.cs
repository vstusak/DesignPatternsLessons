using Factory;

public class DeliveryInfo
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string PostalCode { get; set; }

    public DestinationCountry Country { get; set; }

}