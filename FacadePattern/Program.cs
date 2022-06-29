// See https://aka.ms/new-console-template for more information

using FacadePattern;

var locationLookupService = new LocationLookupService();
var weatherService = new WeatherService();
var temperatureConverterService = new TemperatureConverterService();
var weatherFacadeService = new WeatherFacadeService(locationLookupService, weatherService, temperatureConverterService);
//--------------------------------------------------------------------

string zip = "61300";
//var city = locationLookupService.GetCity(zip);
//var state = locationLookupService.GetState(zip);
//var fahrenheit = weatherService.GetFahrenheit(city, state);
//var celsius = temperatureConverterService.ToCelsius(fahrenheit);
//Console.WriteLine($"Weather for {city.Name}, {state.Name} is {fahrenheit}F/{celsius}C");

var weatherResult = weatherFacadeService.GetWeather(zip);
Console.WriteLine($"Weather for {weatherResult.City.Name}, {weatherResult.State.Name} is {weatherResult.Fahrenheit}F/{weatherResult.Celsius}C");
