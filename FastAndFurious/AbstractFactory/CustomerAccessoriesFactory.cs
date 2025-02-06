namespace AbstractFactory;

public class CustomerAccessoriesProviderFactory : ICustomerAccessoriesProviderFactory
{
    public ICustomerAccessoriesProvider GetCustomerAccessoriesProvider(CustomerType customerType)
    {
        return customerType switch
        {
            CustomerType.Regular when account.Type == AccountType.Regular => CardType.Debet,
            CustomerType.Authorized => CardType.Credit,
            CustomerType.Businessman => CardType.Credit,
            CustomerType.Undefined => throw new ArgumentOutOfRangeException(nameof(customerType), customerType, null),
            _ => throw new ArgumentOutOfRangeException(nameof(customerType), customerType, null)
        };
    }
}

public class RegularCustomerAccessoriesProvider : ICustomerAccessoriesProvider
{
    public Card GetCard(Account account)
    {
        throw new NotImplementedException();
    }

    public Account GetAccount(int customerId)
    {
        throw new NotImplementedException();
    }
}

public class AuthorizedCustomerAccessoriesProvider : ICustomerAccessoriesProvider
{
    public Card GetCard(Account account)
    {
        throw new NotImplementedException();
    }

    public Account GetAccount(int customerId)
    {
        throw new NotImplementedException();
    }
}

public class BusinessmanCustomerAccessoriesProvider : ICustomerAccessoriesProvider
{
    public Card GetCard(Account account)
    {
        throw new NotImplementedException();
    }

    public Account GetAccount(int customerId)
    {
        throw new NotImplementedException();
    }
}