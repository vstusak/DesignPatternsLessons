namespace DecoratorPattern.Plugins;

public class FacebookNotificatorPlugin : INotificatorPlugin
{
    public string Name { get; } = nameof(FacebookNotificatorPlugin);

    public void BeforeRaiseEvent()
    {
        Console.WriteLine("Before Event: Notification will be sent to Facebook.");
    }

    public void AfterRaiseEvent()
    {
        Console.WriteLine("After Event: Notification has been sent to Facebook.");
    }
}