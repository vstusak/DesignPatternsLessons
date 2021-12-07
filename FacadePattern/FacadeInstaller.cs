using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FacadePattern
{
    public class FacadeInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<ITemperatureConventorService>().ImplementedBy<TemperatureConventorService>());
            //container.Register(Component.For<ILocationLookUpService>().ImplementedBy<LocationLookUpService>());
            //container.Register(Component.For<IWeatherService>().ImplementedBy<WeatherService>());

            //container.Register(Component.For<IFacadeClass>().ImplementedBy<FacadeClass>());

            var types = Assembly
                .GetAssembly(typeof(IAutoInstall))
                .GetTypes();

            foreach (var type in types)
            {
                if (!type.IsInterface
                    && !type.IsAbstract
                    && type.IsAssignableTo(typeof(IAutoInstall)))
                {
                    var interfaces = type.GetInterfaces()[0];
                    container.Register(Component.For(interfaces).ImplementedBy(type));
                }
            }
        }
    }
}