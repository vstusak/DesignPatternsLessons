namespace RepositoryPattern.Context
{
    public class Customer
    {
        public Customer()
        {
            CustomerId = System.Guid.NewGuid();
        }

        public System.Guid CustomerId { get; private set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }
    }
}