// See https://aka.ms/new-console-template for more information


using Microsoft.VisualBasic.CompilerServices;
using PrototypePattern;

Console.WriteLine("Hello, Prototype!");

var person = new Person()
{
    Name = "Quido Novak",
    Age = 35,
    Address = new Address()
    {
        Street = "Patockova 10",
        City = "Beroun",
        ZipCode = "12345"
    }
};
Console.WriteLine("Prototype:");
Console.WriteLine(person.ToString());
Console.WriteLine("RefCopy:");
var refPerson = person;
Console.WriteLine(refPerson.ToString());
Console.WriteLine("ShallowCopy");
var shallowPerson = person.ShallowCopy();
Console.WriteLine(shallowPerson.ToString());
Console.WriteLine("Are the shallow and person the same?");
Console.WriteLine("Person: " + Object.ReferenceEquals(person, shallowPerson));
Console.WriteLine("Id: " + Object.ReferenceEquals(person.Id, shallowPerson.Id));
Console.WriteLine("Name: " + Object.ReferenceEquals(person.Name, shallowPerson.Name));
Console.WriteLine("Age: " + Object.ReferenceEquals(person.Age, shallowPerson.Age));
Console.WriteLine("Address: " + Object.ReferenceEquals(person.Address, shallowPerson.Address));

person.Address.City = "Prague";
Console.WriteLine(person.ToString());
Console.WriteLine(shallowPerson.ToString());




