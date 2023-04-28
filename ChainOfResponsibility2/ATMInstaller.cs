using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ChainOfResponsibility2.Handlers;

public class ATMInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        //TODO: Initialize from file
        xxxx

        container.Register(Component.For<IBankNotesResource>().ImplementedBy<BankNotesResource>().LifestyleSingleton());
        container.Register(Component.For<IExceptionLoggerHandler>().ImplementedBy<ValidationExceptionLoggerHandler>());
        container.Register(Component.For<IExceptionNotificationHandler>().ImplementedBy<ValidationExceptionNotificatorHandler>());
        container.Register(Component.For<IExceptionHandlerFactory>().ImplementedBy<ExceptionChainFactory>());

        container.Register(Component.For<IAtmFactory>().ImplementedBy<AtmFactory>().LifestyleSingleton());
        
        //to create List<object> in container:
        container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel));

        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<DefaultHandler>());
        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<IsBalanceToPayValidValidationHandler>());

        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<IsSumResourcesAvailableValidationHandler>());
        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<IsNotesAvailableValidationHandler>());

        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<CashHandler>().Named("5000").DependsOn(Dependency.OnValue<BankNoteDenomination>(BankNoteDenomination.FiveThousand)));
        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<CashHandler>().Named("2000").DependsOn(Dependency.OnValue<BankNoteDenomination>(BankNoteDenomination.TwoThousand)));
        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<CashHandler>().Named("1000").DependsOn(Dependency.OnValue<BankNoteDenomination>(BankNoteDenomination.OneThousand)));
        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<CashHandler>().Named("500").DependsOn(Dependency.OnValue<BankNoteDenomination>(BankNoteDenomination.FiveHundred)));
        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<CashHandler>().Named("200").DependsOn(Dependency.OnValue<BankNoteDenomination>(BankNoteDenomination.TwoHundred)));
        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<CashHandler>().Named("100").DependsOn(Dependency.OnValue<BankNoteDenomination>(BankNoteDenomination.OneHundred)));
        container.Register(Component.For<IHandlerConfigurationInfo>().ImplementedBy<CashHandler>().Named("400").DependsOn(Dependency.OnValue<BankNoteDenomination>(BankNoteDenomination.FourHundred)));

    }
}