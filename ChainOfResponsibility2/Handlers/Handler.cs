namespace ChainOfResponsibility2.Handlers;

public abstract class Handler : IHandler
{
    private IHandler _next;

    public virtual void Handle(int balanceToPay)
    {
        _next?.Handle(balanceToPay);
    }

    public IHandler SetNext(IHandler next)
    {
        _next = next;
        return next;
    }
}