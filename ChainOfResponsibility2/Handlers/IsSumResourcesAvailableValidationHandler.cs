namespace ChainOfResponsibility2.Handlers;

public class IsSumResourcesAvailableValidationHandler : Handler
{
    private BankNotesResource resource;

    public IsSumResourcesAvailableValidationHandler(BankNotesResource resource, ValidationExceptionLoggerHandler exceptionChain)
    {
        this.resource = resource;
    }

    public override void Handle(int balanceToPay)
    {
        if (resource.GetTotalBalance() < balanceToPay)
        {
            Console.WriteLine($"Amount {balanceToPay} is not available in resource (insufficient total).");
        }
        else
        {
            base.Handle(balanceToPay);
        }
    }
}