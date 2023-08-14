namespace ObjectChatApplicationMediator.Positions;

public class Dev:IRecipient
{
    private IMediatorDev _mediator;
    public string Name { get; set; }
    
    public Dev(string name, IMediatorDev mediator)
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
        _mediator.SendToAll(GetType().Name);
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