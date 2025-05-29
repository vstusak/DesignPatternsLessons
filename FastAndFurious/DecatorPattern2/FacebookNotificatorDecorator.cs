namespace DecoratorPattern;

public class FacebookNotificatorDecorator : INotificator
{
    private readonly INotificator _baseNotificator;

    public FacebookNotificatorDecorator(INotificator baseNotificator)
    {
        _baseNotificator = baseNotificator;
    }
    public void RaiseEvent()
    {
        _baseNotificator.RaiseEvent();
        Console.WriteLine("Notification has been sent to Facebook.");
    }
}