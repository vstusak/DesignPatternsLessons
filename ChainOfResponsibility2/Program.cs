using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using ChainOfResponsibility2.Handlers;

var assembly = typeof(BankNotesResource).Assembly;

//From file:
//var fileName = "installer.xml";
//var interpreter = new XmlInterpreter(fileName);
//var container = new WindsorContainer(interpreter);

var container = new WindsorContainer();
container.Install(new ATMInstaller());

var desiredBalance = 3400;
var resource = container.Resolve<IBankNotesResource>();

Console.WriteLine($"Available in resources: {resource.GetTotalBalance()}");
Console.WriteLine($"Want to pay: {desiredBalance}");

//var exceptionLoggerHandler = new ValidationExceptionLoggerHandler(resource);
//var exceptionNotificationHandler = new ValidationExceptionNotificatorHandler(resource);

//var exceptionChainFactory = container.Resolve<IExceptionHandlerFactory>(); //new ExceptionChainFactory(exceptionLoggerHandler, exceptionNotificationHandler);

var atmFactory = container.Resolve<IAtmFactory>();
var chain = atmFactory.GetChain();

//var handler = new IsBalanceToPayValidValidationHandler(resource, exceptionChainFactory);
//handler.SetNext(new IsSumResourcesAvailableValidationHandler(resource, exceptionChainFactory))
  //  .SetNext(new IsNotesAvailableValidationHandler(resource, exceptionChainFactory))
    
    //.SetNext(new CashHandler(BankNoteDenomination.FiveThousand, resource))
    //.SetNext(new CashHandler(BankNoteDenomination.TwoThousand, resource))
    //.SetNext(new CashHandler(BankNoteDenomination.OneThousand, resource))
    //.SetNext(new CashHandler(BankNoteDenomination.FiveHundred, resource))
    //.SetNext(new CashHandler(BankNoteDenomination.FourHundred, resource))
    //.SetNext(new CashHandler(BankNoteDenomination.TwoHundred, resource))
    //.SetNext(new CashHandler(BankNoteDenomination.OneHundred, resource));

chain.Handle(desiredBalance);
