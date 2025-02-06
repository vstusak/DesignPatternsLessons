namespace AbstractFactory;

public interface ICustomerAccessoriesProviderFactory
{
    ICustomerAccessoriesProvider GetCustomerAccessoriesProvider(CustomerType customerType);
}