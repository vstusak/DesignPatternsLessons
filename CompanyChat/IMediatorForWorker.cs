namespace CompanyChat
{
    internal interface IMediatorForWorker
    {
        void SendMessageToAll(string message, ISupportMediator from);
        void SendMessageToAll<T>(string message, ISupportMediator from);
    }
}