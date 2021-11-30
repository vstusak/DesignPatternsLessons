namespace FacadePattern
{
    public interface ITemperatureConventorService
    {
        int ToCelsia(int fahrenheit);
        int ToFahrenheit(int celsia);
    }
}