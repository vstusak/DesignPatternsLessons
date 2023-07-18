using ATM.Handlers;

public class HandlerChainFactory : IHandlerChainFactory
{
    private readonly IList<IHandler> handlers;

    public HandlerChainFactory(IList<IHandler> handlers)
    {
        this.handlers = handlers;
    }

    public IHandler GetChain()
    {
        var validationHandlers =
            handlers.Where(handler => handler.HandlerType == HandlerType.ValidationHandler).ToList();
        var bankNoteHandlers = handlers
            .Where(handler => handler.HandlerType == HandlerType.BankNoteHandler)
            .OrderByDescending(handler => handler.Order);

        var firstHandler = handlers.Single(handler => handler.HandlerType == HandlerType.FirstHandler);
        var handler = firstHandler;

        foreach (var validationHandler in validationHandlers)
        {
            handler = handler.SetNext(validationHandler);
        }

        foreach (var bankNoteHandler in bankNoteHandlers)
        {
            handler = handler.SetNext(bankNoteHandler);
        }

        return firstHandler;
    }
}