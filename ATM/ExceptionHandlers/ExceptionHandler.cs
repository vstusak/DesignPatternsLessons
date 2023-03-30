namespace ATM.ExceptionHandlers;

public abstract class ExceptionHandler : IExceptionHandler
{
    private IExceptionHandler _next;

    public IExceptionHandler SetNext(IExceptionHandler next)
    {
        _next = next;
        return _next;
    }

    public virtual void HandleRequest(string sourceName, int balanceToPay)
    {
        _next?.HandleRequest(sourceName, balanceToPay);
    }
}