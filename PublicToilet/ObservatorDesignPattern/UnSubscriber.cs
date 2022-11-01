using System.Collections.Generic;

namespace PublicToilet.ObservatorDesignPattern
{
    public class UnSubscriber : IOurUnSubscriber
    {
        private List<IOurObserver> _observers;
        private IOurObserver _observer;

        public UnSubscriber(List<IOurObserver> observers, IOurObserver observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void UnSubscribe()
        {
            _observers.Remove(_observer);
        }
    }
}