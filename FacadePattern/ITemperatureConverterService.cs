namespace FacadePattern;

public interface ITemperatureConverterService
{
    int ToCelsius(int f);
    int ToFahrenheit(int c);
}