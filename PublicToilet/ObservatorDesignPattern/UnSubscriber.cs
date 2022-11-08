using System;
using System.Collections.Generic;

namespace PublicToilet.ObservatorDesignPattern
{
    public class UnSubscriber : IOurUnSubscriber
    {
        private List<IOurObserver> _observers;
        private IOurObserver _observer;
        private Guid _guid;

        public UnSubscriber(List<IOurObserver> observers, IOurObserver observer)
        {
            _observers = observers;
            _observer = observer;
            _guid = Guid.NewGuid();
        }

        public void UnSubscribe()
        {
            _observers.Remove(_observer);
        }

        public override string ToString()
        {
            return _guid.ToString();
        }
    }
}