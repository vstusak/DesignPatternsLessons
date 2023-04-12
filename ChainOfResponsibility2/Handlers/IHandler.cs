namespace ChainOfResponsibility2.Handlers;

public interface IHandler
{
    HandlerType HandlerType { get; }
    int HandlerOrder { get; }

    void Handle(int balanceToPay);
    IHandler SetNext(IHandler next);
}