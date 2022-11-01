namespace _04_RepositoryPattern
{
    public class Customer
    {
        public string Name { get; set; }
        public Guid CustomerId { get; private set; }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{CustomerId}, {Name}";
        }
    }
}
