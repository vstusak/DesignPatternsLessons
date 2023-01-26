using ChainOfResponsibility1.Entities;

namespace ChainOfResponsibility1.Handlers
{
    public class SurnameValidationHandler : Handler<Person>
    {
        public override void Handle(Person request)
        {
            if (string.IsNullOrEmpty(request.Surname))
            {
                throw new ArgumentNullException(nameof(request.Surname));
            }
            base.Handle(request);
        }
    }
}
