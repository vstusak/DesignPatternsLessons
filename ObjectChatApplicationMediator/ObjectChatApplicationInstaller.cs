using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ObjectChatApplicationMediator;

public class ObjectChatApplicationInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Component.For<IMediator>().ImplementedBy<Mediator>());
    }
}