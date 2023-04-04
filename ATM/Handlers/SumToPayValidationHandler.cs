namespace ATM.Handlers;

public class SumToPayValidationHandler : Handler
{
    private readonly BankNoteResource _bankNoteResource;
    private readonly IExceptionsChainsFactory _exceptionsChainsFactory;

    public SumToPayValidationHandler(BankNoteResource bankNoteResource,
        IExceptionsChainsFactory exceptionsChainsFactory)
    {
        _bankNoteResource = bankNoteResource;
        _exceptionsChainsFactory = exceptionsChainsFactory;
    }

    public override void HandleRequest(int balanceToPay)
    {
        if (_bankNoteResource.GetCashBalance() < balanceToPay)
        {
            Console.WriteLine("Sorry, we don't have enough banknotes for your request.");
            var exceptionChain = _exceptionsChainsFactory.GetLogAndNotificationExceptionHandlers();
            exceptionChain.HandleRequest(GetType().Name, balanceToPay);
        }
        else
        {
            base.HandleRequest(balanceToPay);
        }
    }
}