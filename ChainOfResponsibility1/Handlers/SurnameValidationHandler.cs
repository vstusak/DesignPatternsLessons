using ChainOfResponsibility1.Entities;

namespace ChainOfResponsibility1.Handlers
{
    public class SurnameValidationHandler : Handler<Person>
    {
        public SurnameValidationHandler(List<string> errorMessages)
        {
            base._errorMessages = errorMessages;
        }
        public override void Handle(Person request)
        {
            if (string.IsNullOrEmpty(request.Surname))
            {
                _errorMessages.Add("Surname validator failed");
                //throw new ArgumentNullException(nameof(request.Surname));
            }
            base.Handle(request);
        }
    }
}
