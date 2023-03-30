namespace ATM.ExceptionHandlers;

public class LogExceptionHandler : ExceptionHandler
{
    public override void HandleRequest(string sourceName,int balanceToPay)
    {
        Console.WriteLine($"This is {GetType().Name}");
        Console.WriteLine($"Source of exception is {sourceName}");
        base.HandleRequest(sourceName,balanceToPay);
    }
}