namespace ATM.Handlers;

internal class BanknoteHandler : Handler
{
    private readonly BankNotesDenomination _banknoteDenomination;
    private readonly BankNoteResource _bankNoteResource;

    public BanknoteHandler(BankNotesDenomination banknoteDenomination, BankNoteResource bankNoteResource)
    {
        _banknoteDenomination = banknoteDenomination;
        _bankNoteResource = bankNoteResource;
    }

    public override void HandleRequest(int balanceToPay)
    {
        var needed = balanceToPay / (int)_banknoteDenomination;
        var registryCount = _bankNoteResource.GetBankNoteCount(_banknoteDenomination);
        if (registryCount >= needed)
        {
            _bankNoteResource.DeductBankNotes(_banknoteDenomination, needed);
            balanceToPay = balanceToPay % (int)_banknoteDenomination;
            Console.WriteLine($"We are paying out {needed} × {_banknoteDenomination} banknotes");
        }
        else
        {
            _bankNoteResource.DeductBankNotes(_banknoteDenomination, registryCount);
            balanceToPay -= registryCount * (int)_banknoteDenomination;
            Console.WriteLine($"We are paying out {registryCount} × {_banknoteDenomination} banknotes");
        }

        base.HandleRequest(balanceToPay);
    }
}