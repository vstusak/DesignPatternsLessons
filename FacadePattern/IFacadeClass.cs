namespace FacadePattern
{
    public interface IFacadeClass: IAutoInstall
    {
        WeatherFacadeResult GetWeather(string zip);
    }
}