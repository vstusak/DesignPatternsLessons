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
        container.Register(Component.For<IHandlerChainFactory>().ImplementedBy<HandlerChainFactory>()
            .LifestyleSingleton());
        container.Register(Component.For<IBankNoteResource>().ImplementedBy<BankNoteResource>().LifestyleSingleton());

        container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));
        container.Register(Component.For<IHandler>().ImplementedBy<AmountToPayValidationHandler>());
        container.Register(Component.For<IHandler>().ImplementedBy<SumToPayValidationHandler>());
        container.Register(Component.For<IHandler>().ImplementedBy<BanknoteHandler>().DependsOn(Dependency.OnValue<BankNotesDenomination>(BankNotesDenomination.BankNote5000)).Named(BankNotesDenomination.BankNote5000.ToString()));
        container.Register(Component.For<IHandler>().ImplementedBy<BanknoteHandler>().DependsOn(Dependency.OnValue<BankNotesDenomination>(BankNotesDenomination.BankNote2000)).Named(BankNotesDenomination.BankNote2000.ToString()));
        container.Register(Component.For<IHandler>().ImplementedBy<BanknoteHandler>().DependsOn(Dependency.OnValue<BankNotesDenomination>(BankNotesDenomination.BankNote1000)).Named(BankNotesDenomination.BankNote1000.ToString()));
        container.Register(Component.For<IHandler>().ImplementedBy<BanknoteHandler>().DependsOn(Dependency.OnValue<BankNotesDenomination>(BankNotesDenomination.BankNote500)).Named(BankNotesDenomination.BankNote500.ToString()));
        container.Register(Component.For<IHandler>().ImplementedBy<BanknoteHandler>().DependsOn(Dependency.OnValue<BankNotesDenomination>(BankNotesDenomination.BankNote200)).Named(BankNotesDenomination.BankNote200.ToString()));
        container.Register(Component.For<IHandler>().ImplementedBy<BanknoteHandler>().DependsOn(Dependency.OnValue<BankNotesDenomination>(BankNotesDenomination.BankNote100)).Named(BankNotesDenomination.BankNote100.ToString()));
    }
}