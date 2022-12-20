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
Console.WriteLine($"Are name strings the same?: {Object.ReferenceEquals(person.Name, shallow.Name)}");
person.Name = "Babadook";
Console.WriteLine($"Are name strings the same?: {Object.ReferenceEquals(person.Name, shallow.Name)}");

var deep = person.DeepCopy();
Console.WriteLine(deep);
Console.WriteLine($"Are deep and person the same object?: {Object.ReferenceEquals(person, deep)}");
Console.WriteLine($"Are the inner objects the same?: {Object.ReferenceEquals(person.Address, deep.Address)}");
Console.WriteLine($"Are name strings the same?: {Object.ReferenceEquals(person.Name, deep.Name)}");

//@TODO Deep copy
