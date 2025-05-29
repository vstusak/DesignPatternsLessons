namespace DecoratorPattern;

public interface INotificator
{
    void RaiseEvent();
}

public class BaseNotificator : INotificator
{

    public BaseNotificator()
    {

    }
    public void RaiseEvent()
    {
        Console.WriteLine("Event raised");
    }
}