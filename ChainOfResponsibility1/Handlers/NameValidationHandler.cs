using ChainOfResponsibility1.Entities;

namespace ChainOfResponsibility1.Handlers
{
    public class NameValidationHandler : Handler<Person>
    {
        public override void Handle(Person request)
        {
            if(string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }
            base.Handle(request);
        }
    }
}
