namespace ObjectChatApplication.Positions;

public class Worker : Person
{
    public Worker(string name)
    {
        Name = name;
        PositionType = PositionType.Worker;
    }

    public override void SentToAll()
    {
        foreach (var recipient in AllRecipients.Where(r=>r.PositionType!=PositionType.Ceo))
        {
            recipient.MessageReceived(Name);
        }
    }


}