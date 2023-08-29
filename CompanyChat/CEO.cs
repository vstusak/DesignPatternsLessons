namespace CompanyChat;

public class CEO : ICeo
{
    private readonly IMediator _mediator;

    public CEO(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void SendMessage(string message)
    {
        _mediator.SendMessageToAll(message, GetType().Name);
    }

    public void ReceiveMessage(string message, string from)
    {
        Console.WriteLine($"{GetType().Name} received message: '{message}' ({from})");
    }
}