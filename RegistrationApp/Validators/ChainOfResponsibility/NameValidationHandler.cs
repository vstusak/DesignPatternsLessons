using RegistrationApp.Models;

namespace RegistrationApp.Validators.ChainOfResponsibility;

public class NameValidationHandler : Handler<Person>
{
    public override void HandleRequest(Person request)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            throw new ArgumentException("The name is empty");
        }
        base.HandleRequest(request);
    }
}