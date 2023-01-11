using RegistrationApp.Models;

namespace RegistrationApp.Validators.ChainOfResponsibility;

public class NinoValidationHandler : Handler<Person>
{
    private NinoValidator ninoValidator;

    public NinoValidationHandler(NinoValidator ninoValidator, List<string> errorMessages)
        : base(errorMessages)
    {
        this.ninoValidator = ninoValidator;
    }

    public override void HandleRequest(Person request)
    {
        if (!ninoValidator.Validate(request.Nino, request.DateOfBirth))
        {
            ErrorMessages.Add("Nino is not valid");
        }
        base.HandleRequest(request);
    }
}