namespace ATM.Handlers;

public abstract class Handler : IHandler
{
    private IHandler _next;

    public IHandler SetNext(IHandler next)
    {
        _next = next;
        return _next;
    }

    public virtual void HandleRequest(int balanceToPay)
    {
        if(balanceToPay == 0)
        {
            Console.WriteLine("Enjoy your cash! Good bye");
            return;
        }
        Console.WriteLine($"Go to next in chain with balance {balanceToPay}");
        _next?.HandleRequest(balanceToPay);
    }    
}