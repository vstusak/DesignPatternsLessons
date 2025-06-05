namespace DecoratorPattern.Plugins;

public class InstagramNotificatorPlugin : INotificatorPlugin
{
    public string Name { get; } = nameof(InstagramNotificatorPlugin);

    public void BeforeRaiseEvent()
    {
        Console.WriteLine("Before Event: Notification will be sent to Instagram.");
    }

    public void AfterRaiseEvent()
    {
        Console.WriteLine("After Event: Notification has been sent to Instagram.");
    }
}