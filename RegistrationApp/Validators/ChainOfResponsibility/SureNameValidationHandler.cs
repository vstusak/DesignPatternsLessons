using RegistrationApp.Models;

namespace RegistrationApp.Validators.ChainOfResponsibility;

public class SureNameValidationHandler : Handler<Person>
{
    public SureNameValidationHandler(List<string> errorMessages) : base(errorMessages)
    {
    }

    public override void HandleRequest(Person request)
    {
        if (string.IsNullOrEmpty(request.Surename))
        {
            ErrorMessages.Add("The surename is empty");
        }
        base.HandleRequest(request);
    }
}