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

        var handler = validationHandlers.First();

        for (var i = 1; i < validationHandlers.Count - 1; i++)
        {
            handler = handler.SetNext(validationHandlers[i]);
        }

        foreach (var bankNoteHandler in bankNoteHandlers)
        {
            handler = handler.SetNext(bankNoteHandler);
        }

        // @TODO make return and debug
    }
}