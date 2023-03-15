namespace ChainOfResponsibility2.Handlers;

public class ValidationExceptionNotificatorHandler : ExceptionHandler
{
    private readonly BankNotesResource _resource;

    public ValidationExceptionNotificatorHandler(BankNotesResource resource)
    {
        _resource = resource;
    }

    public override void Handle(int balanceToPay, string handler, string message)
    {
        Console.WriteLine($"I'm notifying about exception from {handler}: {message}");
        base.Handle(balanceToPay, handler, message);
    }
}