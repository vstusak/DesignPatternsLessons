namespace PrototypePattern;

public class Person
{
    public String Name { get; set; }
    public Address Address { get; set; }

    public Guid Id { get;  } = Guid.NewGuid();

    public override string ToString()
    {
        return $"{Name}, {Address} ({Id})";
    }

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone();
    }
}