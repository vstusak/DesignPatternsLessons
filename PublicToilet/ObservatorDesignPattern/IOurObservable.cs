namespace PublicToilet.ObservatorDesignPattern
{
    public interface IOurObservable
    {
        IOurUnSubscriber Subscribe(IOurObserver observer);
        void NotifyAll();
        State GetState();
    }
}