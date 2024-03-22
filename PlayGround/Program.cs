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

var people = new List<Person>();
people.Add(pepa);
people.Add(jarda);
people.Add(lenka);

var names = people.Select(x => x.Name).ToList();
