namespace ChainOfResponsibility2.Handlers;

public interface IHandlerConfigurationInfo : IHandler
{
    HandlerType HandlerType { get; }
    int HandlerOrder { get; }
}