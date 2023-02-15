using ChainOfResponsibility1.Entities;

namespace ChainOfResponsibility1.Handlers
{
    public class AdultValidationHandler:Handler<Person>
    {
        public AdultValidationHandler(List<string> errorMessages)
        {
            base._errorMessages = errorMessages;
        }

        public override void Handle(Person request)
        {

            if (request.DateOfBirth.AddYears(18) < DateTime.Now)
            {
                _errorMessages.Add("Adult validator failed");
                //throw new ArgumentNullException(nameof(request.Name));
            }

            base.Handle(request);
        }
    }
}
