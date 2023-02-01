using ChainOfResponsibility1.Entities;
using ChainOfResponsibility1.Validators;

namespace ChainOfResponsibility1.Handlers
{
    public class NinoValidationHandler: Handler<Person>
    {
        public override void Handle(Person request)
        {
            var validator = new RWSNinoValidator();
            
            if (validator.IsValidNino(request.Nino, request.DateOfBirth) )
            {
                base.Handle(request);
            }
            else
            {
                throw new ArgumentNullException(nameof(request.Name));
            }
        }
    }
}
