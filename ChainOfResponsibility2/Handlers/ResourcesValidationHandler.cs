namespace ChainOfResponsibility2.Handlers;

public class ResourcesValidationHandler : Handler
{
    public override void Handle(int balanceToPay)
    {
        //TODO Validate if there are enough resources to process the payment
        base.Handle(balanceToPay);
    }
}