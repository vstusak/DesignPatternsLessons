namespace ChainOfResponsibility2.Handlers;

public interface IHandler
{
    void Handle(int balanceToPay);
    IHandler SetNext(IHandler next);
}