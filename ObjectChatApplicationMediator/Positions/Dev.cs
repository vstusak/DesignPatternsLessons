namespace ObjectChatApplicationMediator.Positions;

public class Dev:IRecipient
{
    private IMediator _mediator;
    public Dev(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void ReactToMessage(string from)
    {
        Console.WriteLine($"I am {GetType().Name}. Message received from {from}.");
    }

    public void SendToAll()
    {
        _mediator.SendToAll(GetType().Name);
    }
}