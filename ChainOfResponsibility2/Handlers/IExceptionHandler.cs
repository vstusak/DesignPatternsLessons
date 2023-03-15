namespace ChainOfResponsibility2.Handlers;

public interface IExceptionHandler
{
    void Handle(int balanceToPay, string handler, string message);
    IExceptionHandler SetNext(IExceptionHandler next);
}