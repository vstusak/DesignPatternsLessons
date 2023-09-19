namespace CompanyChat
{
    public interface IMediatorForDeveloper
    {
        void SendMessageToAll(string message, ISupportMediator from);
        void SendMessageToGroup<T>(string message, ISupportMediator from);
    }
}