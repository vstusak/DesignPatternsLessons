namespace PrototypePattern;

public class Address
{
    public String Street { get; set; }
    public String City { get; set; }
    public Guid ID { get;  } = Guid.NewGuid();

    public Address(Address input)
    {
        Street = input.Street;
        City = input.City;
    }

    public Address()
    {

    }

    public override string ToString()
    {
        return $"{Street}, {City} ({ID})";
    }
}