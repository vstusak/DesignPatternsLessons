using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FacadePattern;

public class FacadeInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        var autoInstallType = typeof(IAutoInstall);
        //var interfaceType = typeof(IWeatherFacadeService);
        var types = Assembly.GetAssembly(autoInstallType).GetTypes();

        foreach (var type in types)
        {
            if (!type.IsAbstract && !type.IsInterface && type.IsAssignableTo(autoInstallType))
            {
                var interfaceType = type.GetInterfaces().First(t => t != autoInstallType);
                container.Register(Component.For(interfaceType).ImplementedBy(type));
            }
            
        }

        //container.Register(Component.For(interfaceType).ImplementedBy(anyType));

        //container.Register(Component.For<IWeatherFacadeService>().ImplementedBy<WeatherFacadeService>());
        //container.Register(Component.For<ILocationLookupService>().ImplementedBy<LocationLookupService>());
        //container.Register(Component.For<IWeatherService>().ImplementedBy<WeatherService>());
        //container.Register(Component.For<ITemperatureConverterService>().ImplementedBy<TemperatureConverterService>());
    }
}