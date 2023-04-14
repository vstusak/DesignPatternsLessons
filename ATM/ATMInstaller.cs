// See https://aka.ms/new-console-template for more information

using ATM;
using ATM.ExceptionHandlers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Reflection;

internal class ATMInstaller : IWindsorInstaller
{
    public ATMInstaller()
    {
    }

    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Component.For<ILogExceptionHandler>().ImplementedBy<LogExceptionHandler>());
        container.Register(Component.For<INotificationExceptionsHandler>().ImplementedBy<NotificationExceptionsHandler>());
        container.Register(Component.For<IExceptionsChainsFactory>().ImplementedBy<ExceptionsChainsFactory>().LifestyleSingleton());
        container.Register(Component.For<IBankNoteResource>().ImplementedBy<BankNoteResource>().LifestyleSingleton());

        //container.Register(Component.For<IFacadeClass>().ImplementedBy<FacadeClass>());


    }
}