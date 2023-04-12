namespace ChainOfResponsibility2.Handlers;

public class IsSumResourcesAvailableValidationHandler : Handler
{
    private IBankNotesResource _resource;
    private IExceptionHandlerFactory _exceptionFactory;
    public override HandlerType HandlerType => HandlerType.Validation;
    public override int HandlerOrder => 2;

    public IsSumResourcesAvailableValidationHandler(IBankNotesResource resource, IExceptionHandlerFactory exceptionFactory)
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