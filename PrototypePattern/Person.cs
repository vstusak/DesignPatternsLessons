namespace PrototypePattern;

public class Person
{
    public String Name { get; set; }
    public Address Address { get; set; }

    public Guid Id { get;  } = Guid.NewGuid();

    public Person(Person input)
    {
        Name = input.Name;
        Address = new Address(input.Address);        
    }

    public Person()
    {

    }

    public override string ToString()
    {
        return $"{Name}, {Address} ({Id})";
    }

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone();
    }

    public Person DeepCopy()
    {
        return new Person(this);
    }

    //Old DeepCopy implementation
    //public Person DeepCopyOld()
    //{
    //    Person person = new Person()
    //    {
    //        Name = this.Name,
    //        Address = new Address()
    //        {
    //            City = this.Address.City,
    //            Street = this.Address.Street
    //        }
    //    };
    //    return person;
    //}
}