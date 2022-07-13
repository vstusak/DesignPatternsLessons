using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FacadePattern;

public class FacadeInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Component.For<ILocationLookupService>().ImplementedBy<LocationLookupService>());
        container.Register(Component.For<IWeatherService>().ImplementedBy<WeatherService>());
        container.Register(Component.For<ITemperatureConverterService>().ImplementedBy<TemperatureConverterService>());
        container.Register(Component.For<IWeatherFacadeService>().ImplementedBy<WeatherFacadeService>());
    }
}