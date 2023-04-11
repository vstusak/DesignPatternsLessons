
public class OrderNotificator : IOrderNotificator
{
    public void SendNotification(string notificationMessage)
    {
        Console.WriteLine(notificationMessage);
    }
}
