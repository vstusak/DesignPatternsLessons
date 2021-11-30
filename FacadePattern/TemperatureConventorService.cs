namespace FacadePattern
{
    public class TemperatureConventorService : ITemperatureConventorService
    {
        public int ToCelsia(int fahrenheit)
        {
            double celsius = (5.0 / 9.0) * (fahrenheit - 32);
            return (int)celsius;
        }

        public int ToFahrenheit(int celsia)
        {
            double fahrenheit = celsia * (1.8 + 32);
            return (int)fahrenheit;
        }
    }
}