namespace ChainOfResponsibility2.Handlers;

class AtmFactory : IAtmFactory
{
    private readonly IList<IHandler> _handlers;

    public AtmFactory(IList<IHandler> handlers)
    {
        _handlers = handlers;
    }
    public IHandler GetChain()
    {
        var validationBlocks = _handlers.Where(h => h.HandlerType == HandlerType.Validation).OrderBy(h => h.HandlerOrder);
        var cashBlocks = _handlers.Where(h => h.HandlerType == HandlerType.Cash).OrderByDescending(h => h.HandlerOrder);

        var chain = _handlers.Single(h => h.HandlerType == HandlerType.Default);

        foreach (var block in validationBlocks)
        {
            chain = chain.SetNext(block);
        }

        foreach (var block in cashBlocks)
        {
            chain = chain.SetNext(block);
        }

        return chain;
    }
}