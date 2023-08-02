namespace ObjectChatApplicationMediator.Positions;

public class Dev
{
    private IMediator _mediator;
    public Dev(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void ReactToMessage(string from)
    {
        Console.WriteLine($"I am {GetType()}. Message received from {from}.");
    }
}