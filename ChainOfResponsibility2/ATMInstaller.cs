using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ChainOfResponsibility2.Handlers;

public class ATMInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Component.For<IExceptionLoggerHandler>().ImplementedBy<ValidationExceptionLoggerHandler>());
        container.Register(Component.For<IExceptionNotificationHandler>().ImplementedBy<ValidationExceptionNotificatorHandler>());
        container.Register(Component.For<IExceptionHandlerFactory>().ImplementedBy<ExceptionChainFactory>());

        container.Register(Component.For<IBankNotesResource>().ImplementedBy<BankNotesResource>().LifestyleSingleton());
        
        //to create List<object> in container:
        container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));

        //TODO: Finalise IOC for List of handlers
        xxx;
    }
}