using Castle.Windsor;
using ChainOfResponsibility2.Handlers;

var container = new WindsorContainer();

container.Install(new ATMInstaller());

var desiredBalance = 3400;
var resource = container.Resolve<IBankNotesResource>();

Console.WriteLine($"Available in resources: {resource.GetTotalBalance()}");
Console.WriteLine($"Want to pay: {desiredBalance}");

//var exceptionLoggerHandler = new ValidationExceptionLoggerHandler(resource);
//var exceptionNotificationHandler = new ValidationExceptionNotificatorHandler(resource);

var exceptionChainFactory = container.Resolve<IExceptionHandlerFactory>(); //new ExceptionChainFactory(exceptionLoggerHandler, exceptionNotificationHandler);

var handler = new IsBalanceToPayValidValidationHandler(resource, exceptionChainFactory);
handler.SetNext(new IsSumResourcesAvailableValidationHandler(resource, exceptionChainFactory))
    .SetNext(new IsNotesAvailableValidationHandler(resource, exceptionChainFactory))
    
    .SetNext(new CashHandler(BankNoteDenomination.FiveThousand, resource))
    .SetNext(new CashHandler(BankNoteDenomination.TwoThousand, resource))
    .SetNext(new CashHandler(BankNoteDenomination.OneThousand, resource))
    .SetNext(new CashHandler(BankNoteDenomination.FiveHundred, resource))
    .SetNext(new CashHandler(BankNoteDenomination.FourHundred, resource))
    .SetNext(new CashHandler(BankNoteDenomination.TwoHundred, resource))
    .SetNext(new CashHandler(BankNoteDenomination.OneHundred, resource));

handler.Handle(desiredBalance);