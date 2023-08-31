namespace CompanyChat;

public class Mediator : IMediator, IMediatorForDeveloper, IMediatorForWorker
{
    private readonly List<ISupportMediator> _recipients = new();

    public void AddRecipient(ISupportMediator recipient)
    {
        _recipients.Add(recipient);
    }

    public void SendMessageToAll(string message, ISupportMediator from)
    {
        foreach (var recipient in GetRecipients(from))
        {
            recipient.ReceiveMessage(message, from.GetType().Name);
        }
    }

    public void SendMessageToAll<T>(string message, ISupportMediator from)
    {
        foreach (var recipient in GetRecipients<T>(from))
        {
            recipient.ReceiveMessage(message, from.GetType().Name);
        }
    }

    //void IMediatorForDeveloper.SendMessageToAll(string message, ISupportMediator from)
    {
        foreach (var recipient in GetRecipients(from))
        {
            recipient.ReceiveMessage(message, from.GetType().Name);
        }
    }

    //void IMediatorForWorker.SendMessageToAll(string message, ISupportMediator from)
    {
        foreach (var recipient in GetRecipients(from))
        {
            recipient.ReceiveMessage(message, from.GetType().Name);
        }
    }

    private List<ISupportMediator> GetRecipients<T>(ISupportMediator from)
    {
        return _recipients.Where(recipient => !recipient.Equals(from) && typeof(T) == recipient.GetType()).ToList();
    }

    private List<ISupportMediator> GetRecipients(ISupportMediator from) =>
        _recipients.Where(recipient => !recipient.Equals(from)).ToList();
}