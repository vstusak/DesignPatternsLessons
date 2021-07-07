namespace FactoryPattern
{
    public class DeliveryInfo
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public string PaymentOptions { get; private set; }
        public double Tax { get; private set; }

        public DeliveryInfo(string firstName, string lastName, string address, string paymentOptions, double tax)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PaymentOptions = paymentOptions;
            Tax = tax;
        }
    }
}
