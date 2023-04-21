namespace ChainOfResponsibility2.Handlers;

public class ValidationExceptionNotificatorHandler : ExceptionHandler, IExceptionNotificationHandler
{
    private readonly IBankNotesResource _resource;

    public ValidationExceptionNotificatorHandler(IBankNotesResource resource)
    {
        _resource = resource;
    }

    public override void Handle(int balanceToPay, string handler, string message)
    {
        Console.WriteLine($"I'm notifying about exception from {handler}: {message}");
        base.Handle(balanceToPay, handler, message);
    }
}