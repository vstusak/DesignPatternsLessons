// See https://aka.ms/new-console-template for more information
using IteratorPattern;

var list = new PeopleCollection { new Person("Pepa"), new Person("Radim"), new Person("Anna"), new Person("Lada"), new Person("Borivoj"), new Person("Julia"), new Person("Eva"), new Person("Beata") };
foreach (var item in list)
{
    Console.WriteLine(item.Name);
}

var defaultEnumerator = list.GetEnumerator();
//todo: spustit a pouzit defaultni enumerator z listu
do{
    Console.WriteLine(defaultEnumerator.Current.Name);
}while(defaultEnumerator.MoveNext());
