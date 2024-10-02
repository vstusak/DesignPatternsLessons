﻿namespace ObjectChatApplicationMediator.Positions;

public class Lawyer : IRecipient
{
    private IMediator _mediator;
    public string Name { get; set; }

    public Lawyer(string name, IMediator mediator)
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

    public void SendTo(string to)
    {
        _mediator.SendTo(Name, to);
    }

    public void SendToGroup(Type to)
    {
        _mediator.SendToGroup(Name, to);
    }

}