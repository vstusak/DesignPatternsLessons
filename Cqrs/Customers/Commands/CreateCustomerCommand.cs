namespace CQRS.Customers.Commands
{
    public class CreateCustomerCommand
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }
    }
}
