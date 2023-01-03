using RegistrationApp.Models;

namespace RegistrationApp.Validators
{
    public class PersonValidator
    {
        public bool ValidatePerson(Person person)
        {
            bool IsNameValid = !String.IsNullOrEmpty(person.Name);
            bool IsSureNameValid = !String.IsNullOrEmpty(person.Surename);
            bool IsAdult = person.DateOfBirth.AddYears(18) < DateTime.Now;
            var validator = new NinoValidator();
            var result = validator.Validate(person.Nino, person.DateOfBirth);

            return IsNameValid &&
                   IsSureNameValid &&
                   result &&
                   IsAdult;
        }
    }
}
