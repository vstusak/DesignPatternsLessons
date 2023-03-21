namespace ATM.Handlers;

public class LogExceptionHandler : Handler
{
    private readonly string _nameOfSourceHandler;

    public LogExceptionHandler(string nameOfSourceHandler)
    {
        _nameOfSourceHandler = nameOfSourceHandler;
    }

    public override void HandleRequest(int balanceToPay)
    {
        Console.WriteLine($"This is {GetType().Name}");
        Console.WriteLine($"Source of exception is {_nameOfSourceHandler}");
        base.HandleRequest(balanceToPay);
    }
}