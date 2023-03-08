namespace ChainOfResponsibility2.Handlers;

public class IsNotesAvailableValidationHandler : Handler
{
    private BankNotesResource resource;

    public IsNotesAvailableValidationHandler(BankNotesResource resource)
    {
        this.resource = resource;
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
            Console.WriteLine($"Amount {balanceToPay} is not available in resource (no notes available).");
        }
        else
        {
            base.Handle(balanceToPay);
        }
    }
}