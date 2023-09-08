namespace ObjectChatApplicationMediator.Positions;

public class Dev:IRecipient
{
    private IMediator _mediator;
    public string Name { get; set; }
    
    public Dev(string name, IMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void ReactToMessage(string from)
    {
        Console.WriteLine($"I am {GetType().Name}. Message received from {from}.");
    }

    public void SendToAll()
    {
        _mediator.SendToAll(Name, GetType());
    }

    public void SendTo(string To)
    {
        _mediator.SendTo(Name, To);
    }

    public void SendToGroup(Type to)
    {
        _mediator.SendToGroup(Name, to);
    }
}