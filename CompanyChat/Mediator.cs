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
            recipient.ReceiveMessage(message, from.GetType().Name);
        }
    }

    public void SendMessageToGroup<T>(string message, ISupportMediator from)
    {
        foreach (var recipient in GetRecipients<T>(from))
        {
            recipient.ReceiveMessage(message, from.GetType().Name);
        }
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
    private static readonly Dictionary<Type, List<Type>> ForbidenRecipients = new()
    {
        { typeof(Developer), new List<Type> { typeof(CEO) } },
        { typeof(Worker), new List<Type> { typeof(CEO), typeof(Developer) } }
    };

    public override void SendMessageToAll(string message, ISupportMediator from)
    {
        var recipients = GetRecipients(from);

        var fromType = from.GetType();
        if (ForbidenRecipients.ContainsKey(fromType))
        {
            recipients.RemoveAll(recipient => ForbidenRecipients[fromType].Contains(recipient.GetType()));
        }

        foreach (var recipient in recipients)
        {
            recipient.ReceiveMessage(message, fromType.Name);
        }
    }
}