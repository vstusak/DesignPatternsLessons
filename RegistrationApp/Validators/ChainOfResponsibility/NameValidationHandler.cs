using RegistrationApp.Models;

namespace RegistrationApp.Validators.ChainOfResponsibility;

public class NameValidationHandler : Handler<Person>
{
    public NameValidationHandler(List<string> errorMessages) : base(errorMessages)
    {
    }

    public override void HandleRequest(Person request)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            ErrorMessages.Add("The name is empty");
        }
        base.HandleRequest(request);
    }
}