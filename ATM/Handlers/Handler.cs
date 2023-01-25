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
        _next?.HandleRequest(balanceToPay);
    }
}