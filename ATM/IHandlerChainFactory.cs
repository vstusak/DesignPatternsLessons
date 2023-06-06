using ATM.Handlers;

public interface IHandlerChainFactory
{
    IHandler GetChain();
}