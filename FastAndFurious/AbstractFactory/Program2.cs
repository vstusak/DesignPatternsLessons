namespace AbstractFactory;

public class Program2
{
    public static void Main()
    {
        ICustomerAccessoriesProviderFactory providerFactory = new CustomerAccessoriesProviderFactory();

        var customer = new Customer
        {
            CustomerType = CustomerType.Regular,
            Name = "Pepa",
            CustomerId = 1,
        };

        var provider = providerFactory.GetCustomerAccessoriesProvider(customer.CustomerType);

        var account = provider.GetAccount(customer.CustomerId);
        var card = provider.GetCard(account);

        var customerAccount = new CustomerAccount
        {
            Account = account,
            Card = card,
            Customer = customer
        };
    }
}