namespace ATM.Handlers;

public class NotificationExceptionsHandler : Handler
{
    private readonly string _nameOfSourceHandler;

    public NotificationExceptionsHandler(string nameOfSourceHandler)
    {
        _nameOfSourceHandler = nameOfSourceHandler;
    }

    public override void HandleRequest(int balanceToPay)
    {
        Console.WriteLine($"This is {GetType().Name}");
        Console.WriteLine($"Sending notification about issue on the {_nameOfSourceHandler}");
        base.HandleRequest(balanceToPay);
    }
}