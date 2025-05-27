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
        WriteToOutput("");
        
    }

    public void WriteToOutput(string message)
    {
        _baseNotificator.WriteToOutput(message);
    }
}