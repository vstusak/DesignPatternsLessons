using System;

namespace PublicToilet.ObservatorDesignPattern
{
    public interface IOurObserver
    {
        //Guid Id { get; }
        void NotificationRaised(IOurObservable source);
        void UnSubscribe();
    }
}