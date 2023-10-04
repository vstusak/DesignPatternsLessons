using FlyweightPattern;

Console.ReadLine();

Console.WriteLine("Flyweight!");

var originalSize = GC.GetTotalMemory(false);
Console.WriteLine("Before: " + originalSize.ToString());

var particle = new Particle();

Console.WriteLine("After:  " + GC.GetTotalMemory(false).ToString());
Console.WriteLine("Diff:   " + (GC.GetTotalMemory(false) - originalSize).ToString());


Console.ReadLine();

Console.WriteLine(particle.ToString());
