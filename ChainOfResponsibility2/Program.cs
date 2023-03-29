using Castle.Windsor;
using ChainOfResponsibility2.Handlers;

var desiredBalance = 3400;
var resource = new BankNotesResource();

resource.Add(new BankNote(BankNoteDenomination.OneHundred, 0));
resource.Add(new BankNote(BankNoteDenomination.TwoHundred, 5));
resource.Add(new BankNote(BankNoteDenomination.FourHundred, 2));
resource.Add(new BankNote(BankNoteDenomination.FiveHundred, 2));
resource.Add(new BankNote(BankNoteDenomination.OneThousand, 2));
resource.Add(new BankNote(BankNoteDenomination.TwoThousand, 0));
resource.Add(new BankNote(BankNoteDenomination.FiveThousand, 1));

Console.WriteLine($"Available in resources: {resource.GetTotalBalance()}");
Console.WriteLine($"Want to pay: {desiredBalance}");

// TODO: implement container
var container = new WindsorContainer();

container.Install(new ATMInstaller());

var exceptionLoggerHandler = new ValidationExceptionLoggerHandler(resource);
var exceptionNotificationHandler = new ValidationExceptionNotificatorHandler(resource);

var exceptionChainFactory = new ExceptionChainFactory(exceptionLoggerHandler, exceptionNotificationHandler);

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