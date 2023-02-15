using ChainOfResponsibility1.Entities;

namespace ChainOfResponsibility1.Handlers
{
    public class NameValidationHandler : Handler<Person>
    {
        public NameValidationHandler(List<string> errorMessages)
        {
            base._errorMessages = errorMessages;
        }

        public override void Handle(Person request)
        {
            if(string.IsNullOrEmpty(request.Name))
            {
                _errorMessages.Add("Name validator failed");
                //throw new ArgumentNullException(nameof(request.Name));
            }
            base.Handle(request);
        }
    }
}
