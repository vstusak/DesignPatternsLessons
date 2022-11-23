﻿// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using IteratorPattern;

var people = new PeopleCollection();
people.Add(new Person(){Name="Milan",Age = 666 });
people.Add(new Person() { Name = "Petr Jankovsky", Age = 33 });
people.Add(new Person() { Name = "Petr Pucero", Age = 22 });
people.Add(new Person() { Name = "Josef", Age = 32 });
people.Add(new Person() { Name = "Tomas", Age = 11 });
people.Add(new Person() { Name = "Vlada", Age = 55 });

var peopleForEach = new PeopleCollectionForEach();
peopleForEach.Add(new Person(){Name="Milan",Age = 666 });
peopleForEach.Add(new Person() { Name = "Petr Jankovsky", Age = 33 });
peopleForEach.Add(new Person() { Name = "Petr Pucero", Age = 22 });
peopleForEach.Add(new Person() { Name = "Josef", Age = 32 });
peopleForEach.Add(new Person() { Name = "Tomas", Age = 11 });
peopleForEach.Add(new Person() { Name = "Vlada", Age = 55 });


foreach (var person in people)
{
    Console.WriteLine(person.Name);
}

for (int i = 0; i < people.Count; i++)
{
    Console.WriteLine(people[i].Name);
}

var iterator =  people.CreateIterator();

Console.WriteLine("Own Iterator ---");

while (iterator.Next())
{
    var person = iterator.CurrentPerson;
    Console.WriteLine(person.Name);
}

Console.WriteLine("After At End  Iterator ---");
Console.WriteLine(iterator.CurrentPerson.Name);

Console.WriteLine("List of people (normal) ---");
foreach (var person in people)
{
    Console.WriteLine(person.Name);
}

Console.WriteLine("List of people ForEach ---");

foreach (var person in peopleForEach)
{
    Console.WriteLine(person.Name);
}


