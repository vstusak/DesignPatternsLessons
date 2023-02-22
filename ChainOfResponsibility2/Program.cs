using ChainOfResponsibility2.Handlers;

var handler = new AmountValidationHandler();
handler.SetNext(new ResourcesValidationHandler())
    .SetNext(new CashHandler(BankNotes.FiveThousand))
    .SetNext(new CashHandler(BankNotes.TwoThousand))
    .SetNext(new CashHandler(BankNotes.OneThousand))
    .SetNext(new CashHandler(BankNotes.FiveHundred))
    .SetNext(new CashHandler(BankNotes.TwoHundred))
    .SetNext(new CashHandler(BankNotes.OneHundred));

handler.Handle(1200);
