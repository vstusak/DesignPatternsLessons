namespace ATM.Handlers;

public class SumToPayValidationHandler : Handler
{
    private readonly BankNoteResource _bankNoteResource;

    public SumToPayValidationHandler(BankNoteResource bankNoteResource)
    {
        _bankNoteResource = bankNoteResource;
    }

    public override void HandleRequest(int balanceToPay)
    {
        if (_bankNoteResource.GetCashBalance() < balanceToPay)
        {
            Console.WriteLine("Sorry, we don't have enough banknotes for your request.");
            // @TODO resolve hard dependencies - factory, injection
            SetNext(new LogExceptionHandler(GetType().Name))
                .SetNext(new NotificationExceptionsHandler(GetType().Name));

            //return;
        }

        base.HandleRequest(balanceToPay);
    }
}