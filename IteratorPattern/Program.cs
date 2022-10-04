// See https://aka.ms/new-console-template for more information
using IteratorPattern;

var list = new PeopleCollection { new Person("Pepa"), new Person("Radim"), new Person("Anna"), new Person("Lada"), new Person("Borivoj"), new Person("Julia"), new Person("Eva"), new Person("Beata") };
var list2 = new PeopleCollectionV2 { new Person("Pepa"), new Person("Radim"), new Person("Anna"), new Person("Lada"), new Person("Borivoj"), new Person("Julia"), new Person("Eva"), new Person("Beata") };
Console.WriteLine("Going to use foreach default enumerator");

foreach (var item in list)
{
    Console.WriteLine(item.Name);
}

Console.WriteLine("Going to use while and default enumerator");
var defaultEnumerator = list.GetEnumerator();

while (defaultEnumerator.MoveNext())
{
    Console.WriteLine(defaultEnumerator.Current.Name);
}

Console.WriteLine("Going to use while and our enumerator");
var ourEnumerator = list.CreateIterator();

while (!ourEnumerator.AtEnd())
{
    Console.WriteLine(ourEnumerator.Current().Name);
    ourEnumerator.GetNext();
}

Console.WriteLine("Going to use foreach with our enumerator");

foreach(var item in list2)
{
    Console.WriteLine(item.Name);
}