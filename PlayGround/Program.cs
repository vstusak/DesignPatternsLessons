// See https://aka.ms/new-console-template for more information

using PlayGround;
using System.Xml.Linq;
#region EXTENSION METHODS
//Console.WriteLine("Hello, World!");

//string str = "Hello World!";
//Console.WriteLine(str.ToLower());

////var ext = new Extensions();
////Console.WriteLine(ext.ToLowerCase(str));

//str.ToLowerCase();

//Console.WriteLine(str.CountHigherCases());
#endregion


var pepa = new Person()
{
    Age = 5,
    Birth = new DateTime(2019,01,01),
    Name = "Pepa"
};
var jarda = new Person()
{
    Age = 7,
    Birth = new DateTime(2017, 02, 12),
    Name = "Jarda"
};

var lenka = new Person()
{
    Age = 10,
    Birth = new DateTime(2013, 07, 30),
    Name = "Lenka"
};
var emil = new Person()
{
    Age = 13,
    Birth = new DateTime(2011, 03, 03),
    Name = "Emil"
};

var people = new List<Person>();
people.Add(pepa);
people.Add(jarda);
people.Add(lenka);
people.Add(emil);

//var names = people.Select(x => x.Name);

//foreach (var name in names)
//{
//    System.Console.WriteLine(name);
//}

var peopleWithLowerCaseEinName = people.Where(person => person.Name.Contains('e'));
var peopleWithAnyEinNameString = people.Where(person => person.Name.ToLower().Contains('e'));
var peopleWithEinNameString2 = people.Where(person => person.Name.Contains('e') || person.Name.Contains('E'));
var peopleWithEinNameStringIgnoreCase = people.Where(person => person.Name.Contains("e",StringComparison.InvariantCultureIgnoreCase));

//foreach (var person in peopleWithLowerCaseEinName)
//{
//    System.Console.WriteLine(person);
//}

//foreach (var person in peopleWithAnyEinNameString)
//{
//    System.Console.WriteLine(person);
//}

foreach (var person in peopleWithEinNameString2)
{
    System.Console.WriteLine(person);
}

foreach (var person in peopleWithEinNameStringIgnoreCase)
{
    System.Console.WriteLine(person);
}

//TODO vysvětlit znovu hodnotove a referenční datové typy a jak funguje string (obrazek)
//TODO proč a jak používat stringBuilder