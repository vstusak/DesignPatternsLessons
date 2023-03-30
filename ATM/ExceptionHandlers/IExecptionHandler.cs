namespace ATM.ExceptionHandlers;

public interface IExceptionHandler
{
    IExceptionHandler SetNext(IExceptionHandler next);
    void HandleRequest(string sourceName, int requestedBalance);
}