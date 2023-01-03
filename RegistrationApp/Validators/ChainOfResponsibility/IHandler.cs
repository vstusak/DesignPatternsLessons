namespace RegistrationApp.Validators.ChainOfResponsibility;

public interface IHandler<T> where T : class
{
    IHandler<T> SetNext(IHandler<T> next);
    void HandleRequest(T request);
}