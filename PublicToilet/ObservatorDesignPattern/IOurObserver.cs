namespace PublicToilet.ObservatorDesignPattern
{
    public interface IOurObserver
    {
        void NotificationRaised(IOurObservable source);
        void UnSubscribe();
    }
}