namespace ChainOfResponsibility2.Handlers;

public class CashHandler : Handler
{
    private readonly int _cash;

    public CashHandler(BankNotes cash)
    {
        _cash = (int)cash;
    }

    public override void Handle(int balanceToPay)
    {
        int count = balanceToPay / _cash;

        if(count > 0) 
        {
            Console.WriteLine($"{count}x {_cash}");
        }
            

        var rest = balanceToPay % _cash;

        if(rest > 0)
        {
            base.Handle(rest);
        }
            
    }
}