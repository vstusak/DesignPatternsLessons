using Castle.MicroKernel.Registration;
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
    }
}