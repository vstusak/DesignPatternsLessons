namespace ChainOfResponsibility2.Handlers;

public class IsBalanceToPayValidValidationHandler : Handler
{
    private readonly BankNotesResource _resource;

    public IsBalanceToPayValidValidationHandler(BankNotesResource resource)
    {
        _resource = resource;
    }

    public override void Handle(int balanceToPay)
    {
        if (balanceToPay % _resource.GetLowestDenominant() > 0)
        {
            Console.WriteLine($"Amount {balanceToPay} is not valid.");
        }
        else
        {
            base.Handle(balanceToPay);
        }
    }
}