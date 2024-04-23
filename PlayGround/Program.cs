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

var zirafa = new Animal("Zofka",48, new DateTime(1976, 03, 03));
var defaultPerson = new Person();

var people = new List<Person>();
people.Add(pepa);
people.Add(jarda);
people.Add(lenka);
people.Add(emil);

int? i = null;
int j = i ?? 5;

if (i != null)
{
    j = i.Value;
}
else
{
    j = 5;
}

bool isnotnull = i == null ? false : true;

if (i == null)
{
    isnotnull = false;
}
else
{
    isnotnull = true;
}
//var names = people.Select(x => x.Name);

//foreach (var name in names)
//{
//    System.Console.WriteLine(name);
//}

var peopleWithLowerCaseEinName = people.Where(person => person.Name.Contains('e')); // vybere objekty, ktere v parametru name obsahuji male e (char)
var peopleWithAnyEinNameString = people.Where(person => person.Name.ToLower().Contains('e')); // zmeni pro porovnani objekt string na lower case, male e (char)
var peopleWithEinNameString2 = people.Where(person => person.Name.Contains('e') || person.Name.Contains('E')); // vybere objekt, kde char v name e nebo E
var peopleWithEinNameStringIgnoreCase = people.Where(person => person.Name.Contains("e",StringComparison.InvariantCultureIgnoreCase)); // ignoruje case

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

emil.Age = 14; // pokud je set, tak muzu zmenit objekt pozdeji (emil uz byl vytvoren s vekem 13)
// zirafa.Age = 40; // set je private, nejde pouzit

zirafa.ChangeAge(40); // set je private, ale v metode uvnitr tridy se menit muze. Dela se treba v pripade, ze metoda rozsiruje zmenu (i.e. logovanim)
var jmenoZirafy = zirafa.Name;
//zirafa.Name = "uZofka";

var count = zirafa.LimbCount;

//TODO vysvětlit znovu hodnotove a referenční datové typy a jak funguje string (obrazek)
//TODO proč a jak používat stringBuilder