using Strategy;

Console.WriteLine("Write preferred weather:");
if (!Enum.TryParse<WeatherType>(Console.ReadLine(), true, out var weatherType))
{
    Console.WriteLine("Invalid weather type provided!");
}

Console.WriteLine($"You chose: {weatherType}");

//var dressSelector = new DressSelector(weatherType);
var selfEvaluatedDressSelector = new SelfEvaluatedDressSelector();
Console.WriteLine(selfEvaluatedDressSelector.GetDress(weatherType));
//var dress = dressSelector.GetDress();
//Console.WriteLine(dress);
