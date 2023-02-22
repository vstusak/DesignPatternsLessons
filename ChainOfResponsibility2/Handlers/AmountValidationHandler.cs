namespace ChainOfResponsibility2.Handlers;

public class AmountValidationHandler : Handler
{
    public override void Handle(int balanceToPay)
    {
        if (balanceToPay % Constants.LowestBankNote > 0)
        {
            Console.WriteLine($"Amount {balanceToPay} is not valid.");
        }
        else
        {
            base.Handle(balanceToPay);
        }
    }
}