namespace ATM.Handlers;

public interface IHandler
{
    IHandler SetNext(IHandler next);
    void HandleRequest(int balanceToPay);
}