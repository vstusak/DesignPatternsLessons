namespace DecoratorPattern.Plugins;

public class SlackNotificatorPlugin : INotificatorPlugin
{
    public string Name { get; } = nameof(SlackNotificatorPlugin);

    public void BeforeRaiseEvent()
    {
        Console.WriteLine("Before Event: Notification will be sent to Slack.");
    }

    public void AfterRaiseEvent()
    {
        Console.WriteLine("After Event: Notification has been sent to Slack.");
    }
}