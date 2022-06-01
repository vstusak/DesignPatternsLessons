// See https://aka.ms/new-console-template for more information

using FizzBuzz;

var fizzBuzz = new FizzBuzzGenerator();

Console.WriteLine("String Collection");
var start = DateTime.Now.Ticks;
fizzBuzz.GenerateCollection("1", "200000");
Console.WriteLine(DateTime.Now.Ticks - start);

Console.WriteLine("String Builder");
start = DateTime.Now.Ticks;
fizzBuzz.GenerateStringBuilder("1", "200000");
Console.WriteLine(DateTime.Now.Ticks - start);

Console.WriteLine("String Builder WithoutParsing");
start = DateTime.Now.Ticks;
fizzBuzz.GenerateStringBuilderWithoutParsing("1", "200000");
Console.WriteLine(DateTime.Now.Ticks - start);

Console.WriteLine("String Builder WithoutParsing Aloc");
start = DateTime.Now.Ticks;
fizzBuzz.GenerateStringBuilderWithoutParsingAloc("1", "200000");
Console.WriteLine(DateTime.Now.Ticks - start);

Console.WriteLine("String (/10)");
start = DateTime.Now.Ticks;
fizzBuzz.GenerateString("1", "20000");
Console.WriteLine(DateTime.Now.Ticks - start);

Console.ReadLine();