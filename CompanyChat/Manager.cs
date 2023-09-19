namespace CompanyChat;

public class Manager : IManager
{
    private readonly IMediator _mediator;

    public Manager(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void SendMessageToAll(string message)
    {
        _mediator.SendMessageToAll(message, this);
    }

    public void ReceiveMessage(string message, string from)
    {
        Console.WriteLine($"{GetType().Name} received message: '{message}' ({from})");
    }

    public void SendMessageToGroup<T>(string message)
    {
        _mediator.SendMessageToGroup<T>(message, this);
    }
}