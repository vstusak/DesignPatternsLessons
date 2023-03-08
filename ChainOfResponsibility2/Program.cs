using ChainOfResponsibility2.Handlers;

var desiredBalance = 3100;
var resource = new BankNotesResource();

resource.Add(new BankNote(BankNoteDenomination.OneHundred, 3));
resource.Add(new BankNote(BankNoteDenomination.TwoHundred, 5));
resource.Add(new BankNote(BankNoteDenomination.FiveHundred, 2));
resource.Add(new BankNote(BankNoteDenomination.OneThousand, 2));
resource.Add(new BankNote(BankNoteDenomination.TwoThousand, 0));
resource.Add(new BankNote(BankNoteDenomination.FiveThousand, 1));

Console.WriteLine($"Available in resources: {resource.GetTotalBalance()}");
Console.WriteLine($"Want to pay: {desiredBalance}");

var handler = new IsBalanceToPayValidValidationHandler(resource);
handler.SetNext(new IsSumResourcesAvailableValidationHandler(resource))
    .SetNext(new IsNotesAvailableValidationHandler(resource))
    
    .SetNext(new CashHandler(BankNoteDenomination.FiveThousand, resource))
    .SetNext(new CashHandler(BankNoteDenomination.TwoThousand, resource))
    .SetNext(new CashHandler(BankNoteDenomination.OneThousand, resource))
    .SetNext(new CashHandler(BankNoteDenomination.FiveHundred, resource))
    .SetNext(new CashHandler(BankNoteDenomination.TwoHundred, resource))
    .SetNext(new CashHandler(BankNoteDenomination.OneHundred, resource));

handler.Handle(desiredBalance);


//TODO: Make a more complex workflow.
//TODO: Error handling (comming from handlers)