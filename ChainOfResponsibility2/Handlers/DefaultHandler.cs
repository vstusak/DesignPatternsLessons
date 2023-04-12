namespace ChainOfResponsibility2.Handlers;

public class DefaultHandler : Handler
{
    public override HandlerType HandlerType => HandlerType.Default;
    public override int HandlerOrder => 1;

}