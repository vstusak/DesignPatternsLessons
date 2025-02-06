namespace AbstractFactory;

public interface ICustomerAccessoriesProvider
{
    Card GetCard(Account account);

    Account GetAccount(int customerId);
}