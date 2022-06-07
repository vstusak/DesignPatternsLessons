using FizzBuzz;
//try
//{
//    var buzzGenerator = new FizzBuzzGenerator();
//    Console.Write("Please provide number: ");
//    var input = Console.ReadLine();
//    Console.WriteLine(buzzGenerator.GetSequence(input));
//} catch (Exception ex)
//{
//    Console.WriteLine(ex.ToString());
//}


var buzzGenerator = new FizzBuzzGenerator();
Console.WriteLine("starting string joins");
var start = DateTime.Now.Ticks;
buzzGenerator.GetSequenceStringJoin("1");
var end = DateTime.Now.Ticks;
Console.WriteLine($"Total time for execution {end - start}");
Console.WriteLine("_______________________________________");
Console.WriteLine("starting string builder");
start = DateTime.Now.Ticks;
buzzGenerator.GetSequenceStringBuilder("1");
end = DateTime.Now.Ticks;
Console.WriteLine($"Total time for execution {end - start}");
Console.WriteLine("_______________________________________");
Console.WriteLine("starting strings");
start = DateTime.Now.Ticks;
buzzGenerator.GetSequenceStrings("1");
end = DateTime.Now.Ticks;
Console.WriteLine($"Total time for execution {end - start}");
Console.WriteLine("_______________________________________");
