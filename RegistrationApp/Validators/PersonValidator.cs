using RegistrationApp.Models;
using RegistrationApp.Validators.ChainOfResponsibility;

namespace RegistrationApp.Validators
{
    public class PersonValidator
    {
        //public bool ValidatePerson(Person person)
        //{
        //    bool IsNameValid = !String.IsNullOrEmpty(person.Name);
        //    bool IsSureNameValid = !String.IsNullOrEmpty(person.Surename);
        //    bool IsAdult = person.DateOfBirth.AddYears(18) < DateTime.Now;
        //    var validator = new NinoValidator();
        //    var result = validator.Validate(person.Nino, person.DateOfBirth);

        //    return IsNameValid &&
        //           IsSureNameValid &&
        //           result &&
        //           IsAdult;
        //}

        public List<string> ValidatePerson(Person person)
        {
            var ninoValidator = new NinoValidator();
            var errorMessages = new List<string>();
            var handler = new NameValidationHandler(errorMessages);

            handler
                .SetNext(new SureNameValidationHandler(errorMessages))
                .SetNext(new AdultValidationHandler(errorMessages))
                .SetNext(new AliveValidationHandler(errorMessages))
                .SetNext(new NinoValidationHandler(ninoValidator, errorMessages));
            handler.HandleRequest(person);

            return errorMessages;
        }
    }
}
