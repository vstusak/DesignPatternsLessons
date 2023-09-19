namespace CompanyChat;

public interface IMediator
{
    void AddRecipient(ISupportMediator recipient);
    void SendMessageToAll(string message, ISupportMediator from);
    void SendMessageToGroup<T>(string message, ISupportMediator from);
}