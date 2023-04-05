namespace ChainOfResponsibility2.Handlers;

public class CashHandler : Handler
{
    private readonly IBankNotesResource _resource;
    private readonly BankNoteDenomination _noteDenom;

    public CashHandler(BankNoteDenomination noteDenom, IBankNotesResource resource)
    {
        _resource = resource;
        _noteDenom = noteDenom;
    }

    public override void Handle(int balanceToPay)
    {
        var availableBankNotes = _resource.GetAvailableNotes(_noteDenom);
        
        var countNeeded = balanceToPay / (int)_noteDenom;
        
        var rest = 0;

        if (countNeeded <= availableBankNotes)
        {
            Console.WriteLine($"{countNeeded} x {(int)_noteDenom}");
            _resource.UpdateAvailableNotes(_noteDenom, countNeeded);
            rest = balanceToPay % (int)_noteDenom;
        }
        else
        {
            Console.WriteLine($"{availableBankNotes} x {(int)_noteDenom}");
            _resource.UpdateAvailableNotes(_noteDenom, availableBankNotes);
            rest = balanceToPay - (availableBankNotes * (int)_noteDenom);
        }

        if(rest > 0)
        {
            base.Handle(rest);
        }
            
    }
}