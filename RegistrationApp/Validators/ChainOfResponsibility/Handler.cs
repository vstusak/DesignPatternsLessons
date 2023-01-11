namespace RegistrationApp.Validators.ChainOfResponsibility;

public abstract class Handler<T> : IHandler<T> where T : class
{
    private IHandler<T> _next;

    public List<string> ValidationMessages = new();

    public List<string> ErrorMessages { get; }

    protected Handler(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }

    public IHandler<T> SetNext(IHandler<T> next)
    {
        _next = next;
        return _next;
    }

    public virtual void HandleRequest(T request)
    {
        _next?.HandleRequest(request);
    }
}