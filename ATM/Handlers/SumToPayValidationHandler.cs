namespace ATM.Handlers;

public class SumToPayValidationHandler : Handler
{
    private readonly CashRegister _cashRegister;

    public SumToPayValidationHandler(CashRegister cashRegister)
    {
        _cashRegister = cashRegister;
    }

    public override void HandleRequest(int balanceToPay)
    {
        if (_cashRegister.GetCashBalance() < balanceToPay)
        {
            Console.WriteLine("Sorry, we don't have enought banknotes for your request.");
            return;
        }
        base.HandleRequest(balanceToPay);
    }
}