using Strategy;

if (!Enum.TryParse<WeatherType>(Console.ReadLine(), true, out var weatherType))
{
    Console.WriteLine("Invalid weather type provided!");
}

switch (weatherType)
{
    case WeatherType.Hot:
        Console.WriteLine("T-Shirt");
    case 
}