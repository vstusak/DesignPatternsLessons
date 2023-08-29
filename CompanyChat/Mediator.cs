namespace CompanyChat;

public class Mediator : IMediator
{
    private readonly List<ISupportMediator> _recipients = new();

    public void AddRecipient(ISupportMediator recipient)
    {
        _recipients.Add(recipient);
    }

    public void SendMessageToAll(string message, ISupportMediator from)
    {
        _recipients.Where(recipient => !recipient.Equals(from)).ForEach(recipient =>
            recipient.ReceiveMessage(message,
                from.GetType().Name));
    }
}