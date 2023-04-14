namespace ATM.ExceptionHandlers;

public class NotificationExceptionsHandler : ExceptionHandler, INotificationExceptionsHandler
{
    public override void HandleRequest(string sourceName, int balanceToPay)
    {
        Console.WriteLine($"This is {GetType().Name}");
        Console.WriteLine($"Sending notification about issue on the {sourceName}");
        base.HandleRequest(sourceName, balanceToPay);
    }
}