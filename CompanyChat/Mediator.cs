namespace CompanyChat;

public class Mediator : IMediator //, IMediatorForDeveloper, IMediatorForWorker
{
    private readonly List<ISupportMediator> _recipients = new();

    public void AddRecipient(ISupportMediator recipient)
    {
        _recipients.Add(recipient);
    }

    public virtual void SendMessageToAll(string message, ISupportMediator from)
    {
        foreach (var recipient in GetRecipients(from))
        {
            SendTo(message, from, recipient);
        }
    }

    public void SendMessageToGroup<T>(string message, ISupportMediator from)
    {
        foreach (var recipient in GetRecipients<T>(from))
        {
            SendTo(message, from, recipient);
        }
    }

    protected void SendTo(string message, ISupportMediator from, ISupportMediator recipient)
    {
        recipient.ReceiveMessage(message, from.GetType().Name);
    }

    //void IMediatorForDeveloper.SendMessageToAll(string message, ISupportMediator from)
    //{
    //    foreach (var recipient in GetRecipients(from).Where(x => x.GetType() != typeof(CEO)))
    //    {
    //        recipient.ReceiveMessage(message, from.GetType().Name);
    //    }
    //}

    //void IMediatorForWorker.SendMessageToAll(string message, ISupportMediator from)
    //{
    //    foreach (var recipient in GetRecipients(from).Where(x => x.GetType() != typeof(CEO) && x.GetType() != typeof(Developer)))
    //    {
    //        recipient.ReceiveMessage(message, from.GetType().Name);
    //    }
    //}

    private List<ISupportMediator> GetRecipients<T>(ISupportMediator from)
    {
        return _recipients.Where(recipient => !recipient.Equals(from) && typeof(T) == recipient.GetType()).ToList();
    }

    protected List<ISupportMediator> GetRecipients(ISupportMediator from) =>
        _recipients.Where(recipient => !recipient.Equals(from)).ToList();
}

public class ProxyMediator : Mediator
{
    private static readonly Dictionary<Type, List<Type>> ForbiddenRecipients = new()
    {
        { typeof(Developer), new List<Type> { typeof(CEO) } },
        { typeof(Worker), new List<Type> { typeof(CEO), typeof(Developer) } }
    };

    public override void SendMessageToAll(string message, ISupportMediator from)
    {
        var recipients = FilterRecipients(from);

        foreach (var recipient in recipients)
        {
            SendTo(message, from, recipient);
        }
    }

    private List<ISupportMediator> FilterRecipients(ISupportMediator from)
    {
        var recipients = GetRecipients(from);

        var fromType = from.GetType();
        if (ForbiddenRecipients.ContainsKey(fromType))
        {
            recipients.RemoveAll(recipient => ForbiddenRecipients[fromType].Contains(recipient.GetType()));
        }

        return recipients;
    }
}