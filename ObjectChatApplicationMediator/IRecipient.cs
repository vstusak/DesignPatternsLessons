namespace ObjectChatApplicationMediator
{
    public interface IRecipient
    {
        void ReactToMessage(string from);

        void SendToAll();
    }
}