namespace ChainOfResponsibility2.Handlers;

public class IsBalanceToPayValidValidationHandler : Handler
{
    private readonly BankNotesResource _resource;
    private readonly IExceptionHandlerFactory _exceptionFactory;


    public IsBalanceToPayValidValidationHandler(BankNotesResource resource, IExceptionHandlerFactory exceptionFactory)
    {
        _resource = resource;
        _exceptionFactory = exceptionFactory;
    }

    public override void Handle(int balanceToPay)
    {
        if (balanceToPay % _resource.GetLowestDenominant() > 0)
        {
            Console.WriteLine($"Amount {balanceToPay} is not valid.");

            var handler = _exceptionFactory.GetLoggerExceptionHandler();

            handler.Handle(balanceToPay, GetType().Name, $"Amount {balanceToPay} is not valid.");
        }
        else
        {
            base.Handle(balanceToPay);
        }
    }
}