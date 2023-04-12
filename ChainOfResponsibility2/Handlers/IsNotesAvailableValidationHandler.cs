namespace ChainOfResponsibility2.Handlers;

public class IsNotesAvailableValidationHandler : Handler
{
    private IBankNotesResource resource;
    private IExceptionHandlerFactory _exceptionFactory;
    public override HandlerType HandlerType => HandlerType.Validation;
    public override int HandlerOrder => 3;

    public IsNotesAvailableValidationHandler(IBankNotesResource resource, IExceptionHandlerFactory exceptionFactory)
    {
        this.resource = resource;
        _exceptionFactory = exceptionFactory;
    }

    public override void Handle(int balanceToPay)
    {
        var actualBalance = balanceToPay;

        foreach (var note in this.resource.OrderByDescending(o=>o.NoteValue))
        {
            var availableBankNotes = note.Count;
            var countNeeded = actualBalance / note.NoteValue;
        
            if (countNeeded <= availableBankNotes)
            {
                actualBalance -= (countNeeded * note.NoteValue);
            }
            else
            {
                actualBalance -= (availableBankNotes * note.NoteValue);
            }
            if (actualBalance == 0) break;
        }

        if (actualBalance > 0)
        {
            var message = $"Amount {balanceToPay} is not available in resource (no notes available).";
            // Console.WriteLine(message);

            var handler = _exceptionFactory.GetLoggerAndNotificationExceptionChainHandler();

            handler.Handle(balanceToPay, GetType().Name, $"Amount {balanceToPay} is not available in resource (no notes available).");
            //base.SetNext(new ValidationExceptionLoggerHandler(resource, this.GetType().FullName!, message));
            //base.Handle(balanceToPay);
        }
        else
        {
            base.Handle(balanceToPay);
        }
    }
}