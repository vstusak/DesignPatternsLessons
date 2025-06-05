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
        Console.WriteLine("Before Event: Notification will be sent to Facebook.");
        _baseNotificator.RaiseEvent();
        Console.WriteLine("After Event: Notification has been sent to Facebook.");
    }
}