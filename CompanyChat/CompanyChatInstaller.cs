// See https://aka.ms/new-console-template for more information
//Mediator pattern could be useful for central managing of references.
//OR keep references in each object???

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CompanyChat;

public class CompanyChatInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Component.For<IMediator>().ImplementedBy<Mediator>());
    }
}