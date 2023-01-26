namespace ChainOfResponsibility1.Handlers
{
    public interface IHandler<T> where T : class
    {
        void Handle(T request);
        IHandler<T> SetNext(IHandler<T> next);
    }
}
