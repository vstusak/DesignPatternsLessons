using System.IO;
using NullableGuid = System.Guid?;

using Integers = int[];

using ComplexNumber = (decimal real, decimal imaginary);


var num = new ComplexNumber(2, 4);

NullableGuid nullableG = Guid.Empty;

nullableG = null;

Integers intaci = new[] { 1, 2, 8, 9 };



Person person = new Person("Franta", "Pačes", 33);

Console.WriteLine($"{person.FirstName}, {person.LastName}, {person.Age}, {person.City}");

Person person2 = new Person();

Console.WriteLine($"{person2.FirstName}, {person2.LastName}, {person2.Age}, {person2.City}");

Person person3 = new Person("Saša","MacNovák",12,"Pragueál");

Console.WriteLine($"{person3.FirstName}, {person3.LastName}, {person3.Age}, {person3.City}");


Animal elefik = new Animal(3,"Salon","Bigg",725);

Console.WriteLine($"{elefik.LastName} has {elefik.Legs} legies!");

public  class Person(string firstName, string lastName, int age)
    {
        public string FirstName => firstName;
        public string LastName => lastName;
        public int Age => age;
        public string City { get; private set; }


        public Person():this("Evžen","Burák",24)
        {
         
        }
        public Person(string firstName, string lastName, int age, string city):this(firstName, lastName, age)
        {
            City = city;
        }
    }

public class Animal(int legs, string firstName, string lastName, int age) : Person(firstName,lastName,age)
{
    public int Legs => legs;
}



