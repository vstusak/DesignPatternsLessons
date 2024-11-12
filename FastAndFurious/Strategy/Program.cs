using Strategy;

Console.WriteLine("Write preferred weather:");
if (!Enum.TryParse<WeatherType>(Console.ReadLine(), true, out var weatherType))
{
    Console.WriteLine("Invalid weather type provided!");
}

Console.WriteLine($"You chose: {weatherType}");

DressSelector dressSelector = new DressSelector();
string dress = dressSelector.GetDress(weatherType);
Console.WriteLine(dress);
