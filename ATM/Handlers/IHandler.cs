namespace ATM.Handlers;

public interface IHandler
{
    int Order { get; }
    HandlerType HandlerType { get; } //Todo: split interfaces
    IHandler SetNext(IHandler next);
    void HandleRequest(int balanceToPay);
}