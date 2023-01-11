using RegistrationApp.Models;

namespace RegistrationApp.Validators.ChainOfResponsibility;

public class AdultValidationHandler : Handler<Person>
{
    public AdultValidationHandler(List<string> errorMessages) : base(errorMessages)
    {
    }

    public override void HandleRequest(Person request)
    {
        if (request.DateOfBirth.AddYears(18) > DateTime.Now)
        {
            ErrorMessages.Add("Not an adult");
        }
        base.HandleRequest(request);
    }
}