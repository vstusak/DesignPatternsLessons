namespace ATM.Handlers;

public class AmountToPayValidationHandler : Handler
{
    private readonly IExceptionsChainsFactory _exceptionChainsFactory;

    public AmountToPayValidationHandler(IExceptionsChainsFactory exceptionChainsFactory)
    {
        _exceptionChainsFactory = exceptionChainsFactory;
    }

    public override void HandleRequest(int balanceToPay)
    {
        if (balanceToPay % 100 != 0)
        {
            Console.WriteLine("The requested amount is not valid. It must be devidible by 100.");
            var exceptionChain = _exceptionChainsFactory.GetLogExceptionHandler();
            exceptionChain.HandleRequest(GetType().Name, balanceToPay);
        }
        else
        {
            base.HandleRequest(balanceToPay);
        }
    }
}