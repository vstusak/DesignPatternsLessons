namespace ChainOfResponsibility2.Handlers;

public class DefaultHandler : Handler, IHandlerConfigurationInfo
{
    public HandlerType HandlerType => HandlerType.Default;
    public int HandlerOrder => 1;

}