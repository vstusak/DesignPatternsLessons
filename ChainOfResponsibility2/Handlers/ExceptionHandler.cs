namespace ChainOfResponsibility2.Handlers;

public abstract class ExceptionHandler : IExceptionHandler
{
    private IExceptionHandler _next;
        
    public virtual void Handle(int balanceToPay, string handler, string message)
    {
        _next?.Handle(balanceToPay, handler, message);
    }

    public IExceptionHandler SetNext(IExceptionHandler next)
    {
        _next = next;
        return next;
    }
}