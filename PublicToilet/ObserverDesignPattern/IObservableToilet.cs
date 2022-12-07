using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet.ObserverDesignPattern;

public interface IObservableToilet
{
    Unsubscriber Add(IToiletObserver observerToilet);
    void NotifyAll();
    string GetState();
}