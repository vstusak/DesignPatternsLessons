namespace ObjectChatApplicationMediator
{
    public interface IRecipient
    {
        string Name { get; }

        void ReactToMessage(string from);

        void SendToGroup(Type to);

        void SendTo(string to);

        void SendToAll();
    }
}