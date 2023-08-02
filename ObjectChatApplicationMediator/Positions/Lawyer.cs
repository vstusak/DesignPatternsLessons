namespace ObjectChatApplicationMediator.Positions;

public class Lawyer
{
    private IMediator _mediator;
    public Lawyer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void ReactToMessage(string from)
    {
        Console.WriteLine($"I am {GetType()}. Message received from {from}.");
    }
}