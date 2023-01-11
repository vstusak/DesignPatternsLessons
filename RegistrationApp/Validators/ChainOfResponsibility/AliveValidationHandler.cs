using RegistrationApp.Models;

namespace RegistrationApp.Validators.ChainOfResponsibility;

public class AliveValidationHandler : Handler<Person>
{
    public AliveValidationHandler(List<string> errorMessages) : base(errorMessages)
    {
    }

    public override void HandleRequest(Person request)
    {
        if (request.DateOfBirth < DateTime.Now.AddYears(-120))
        {
            ErrorMessages.Add("Wonderful age. Contact our support.");
        }
        base.HandleRequest(request);
    }
}