namespace ObjectChatApplicationMediator.Positions;

public class Worker
{
    private IMediator _mediator;
    public Worker(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void ReactToMessage(string from)
    {
        Console.WriteLine($"I am {GetType()}. Message received from {from}.");
    }
}