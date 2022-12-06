using PrototypePattern;

var address = new Address()
{
    City = "Brno",
    Street = "Voriskova"
};

var person = new Person()
{
    Address = address,
    Name = "Radim"
};

Console.WriteLine(person);

var copy = person;

Console.WriteLine(copy);

var shallow = person.ShallowCopy();

Console.WriteLine(shallow);
Console.WriteLine($"Are shallow and person the same object?: {Object.ReferenceEquals(person, shallow)}");
Console.WriteLine($"Are the inner objects the same?: {Object.ReferenceEquals(person.Address, shallow.Address)}");

//@TODO Deep copy
