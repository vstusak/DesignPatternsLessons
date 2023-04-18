// See https://aka.ms/new-console-template for more information

using ATM.ExceptionHandlers;
using ATM.Handlers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ATM;

internal class ATMInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Component.For<ILogExceptionHandler>().ImplementedBy<LogExceptionHandler>());
        container.Register(Component.For<INotificationExceptionsHandler>()
            .ImplementedBy<NotificationExceptionsHandler>());
        container.Register(Component.For<IExceptionsChainsFactory>().ImplementedBy<ExceptionsChainsFactory>()
            .LifestyleSingleton());
        container.Register(Component.For<IBankNoteResource>().ImplementedBy<BankNoteResource>().LifestyleSingleton());

        container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
        container.Register(Component.For<IHandler>().ImplementedBy<BanknoteHandler>()
            .DependsOn(Dependency.OnValue<BankNotesDenomination>(BankNotesDenomination.BankNote5000)));
    }
}