namespace ChainOfResponsibility1.Handlers
{
    public abstract class Handler<T> : IHandler<T> where T : class
    {
        private IHandler<T> _next;
        protected List<string> _errorMessages;
        
        public virtual void Handle(T request)
        {
            _next?.Handle(request);
        }

        public IHandler<T> SetNext(IHandler<T> next)
        {
            _next = next;
            return next;
        }
    }
}
