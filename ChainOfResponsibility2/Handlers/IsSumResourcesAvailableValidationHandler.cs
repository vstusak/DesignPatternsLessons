namespace ChainOfResponsibility2.Handlers;

public class IsSumResourcesAvailableValidationHandler : Handler
{
    private BankNotesResource _resource;
    private IExceptionHandlerFactory _exceptionFactory;

    public IsSumResourcesAvailableValidationHandler(BankNotesResource resource, IExceptionHandlerFactory exceptionFactory)
    {
        _resource = resource;
        _exceptionFactory = exceptionFactory;
    }

    public override void Handle(int balanceToPay)
    {
        if (_resource.GetTotalBalance() < balanceToPay)
        {
            Console.WriteLine($"Amount {balanceToPay} is not available in resource (insufficient total).");
            var handler = _exceptionFactory.GetLoggerAndNotificationExceptionChainHandler();
            handler.Handle(balanceToPay, GetType().Name, $"Amount {balanceToPay} is not available in resource (insufficient total).");
        }
        else
        {
            base.Handle(balanceToPay);
        }
    }
}