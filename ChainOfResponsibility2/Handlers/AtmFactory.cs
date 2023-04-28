namespace ChainOfResponsibility2.Handlers;

class AtmFactory : IAtmFactory
{
    private readonly IList<IHandlerConfigurationInfo> _handlers;

    public AtmFactory(IList<IHandlerConfigurationInfo> handlers)
    {
        _handlers = handlers;
    }
    public IHandler GetChain()
    {
        IOrderedEnumerable<IHandler> validationBlocks = _handlers.Where(h => h.HandlerType == HandlerType.Validation).OrderBy(h => h.HandlerOrder);
        IOrderedEnumerable<IHandler> cashBlocks = _handlers.Where(h => h.HandlerType == HandlerType.Cash).OrderByDescending(h => h.HandlerOrder);

        IHandler chain = _handlers.Single(h => h.HandlerType == HandlerType.Default);

        IHandler first = chain;
        foreach (var block in validationBlocks)
        {
            chain = chain.SetNext(block);
        }

        foreach (var block in cashBlocks)
        {
            chain = chain.SetNext(block);
        }

        return first;
    }
}