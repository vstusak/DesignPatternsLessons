namespace CompanyChat;

public interface ISupportMediator
{
    void SendMessageToAll(string message);
    void ReceiveMessage(string message, string from);
    void SendMessageToGroup<T>(string message);
}