namespace PublicToilet.ObserverDesignPattern;

public class Unsubscriber
{
    private readonly List<IToiletObserver> _toiletObservers;
    private readonly IToiletObserver _toiletObserver;
    private readonly Guid _id;

    public Unsubscriber(List<IToiletObserver> toiletObservers, IToiletObserver toiletObserver)
    {
        _toiletObservers = toiletObservers;
        _toiletObserver = toiletObserver;
        _id = Guid.NewGuid();
    }

    public override string ToString()
    {
        return _id.ToString();
    }

    public void RemoveObserver()
    {
        _toiletObservers.Remove(_toiletObserver);
    }

}