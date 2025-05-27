namespace DecoratorPattern;

public interface INotificator
{
    void RaiseEvent();
    void WriteToOutput(string message);
}

public class BaseNotificator : INotificator
{
    private readonly TextBox _output;

    public BaseNotificator(TextBox output)
    {
        _output = output;
    }
    public void RaiseEvent()
    {
        _output.AppendText("Event raised" + Environment.NewLine);
    }

    public void WriteToOutput(string message)
    {
        _output.AppendText(message+Environment.NewLine);
    }
}