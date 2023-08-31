namespace CompanyChat
{
    internal interface IMediatorForDeveloper
    {
        void SendMessageToAll(string message, ISupportMediator from);
        void SendMessageToAll<T>(string message, ISupportMediator from);
    }
}