namespace AbstractFactory;

public class CustomerAccessoriesProviderFactory : ICustomerAccessoriesProviderFactory
{
    public ICustomerAccessoriesProvider GetCustomerAccessoriesProvider(CustomerType customerType)
    {
        return customerType switch
        {
            CustomerType.Regular => new RegularCustomerAccessoriesProvider(),
            CustomerType.RegularSavings => new RegularSavingsCustomerAccessoriesProvider(),
            CustomerType.Authorized => new AuthorizedCustomerAccessoriesProvider(),
            CustomerType.Businessman => new BusinessmanCustomerAccessoriesProvider(),
            CustomerType.Undefined => throw new ArgumentOutOfRangeException(nameof(customerType), customerType, null),
            _ => throw new ArgumentOutOfRangeException(nameof(customerType), customerType, null)
        };
    }
}

public class RegularCustomerAccessoriesProvider : ICustomerAccessoriesProvider
{
    public Card GetCard(Account account)
    {
        return new DebetCard
        {
            AccountId = account.AccountId,
            HolderId = account.CustomerId
        };
    }

    public Account GetAccount(int customerId)
    {
        return new RegularAccount
        {
            CustomerId = customerId
        };
    }
}

public class RegularSavingsCustomerAccessoriesProvider : ICustomerAccessoriesProvider
{
    public Card GetCard(Account account)
    {
        throw new NotImplementedException();
    }

    public Account GetAccount(int customerId)
    {
        return new SavingsAccount
        {
            CustomerId = customerId
        };
    }
}

public class DebetCard : Card
{
}

public class AuthorizedCustomerAccessoriesProvider : ICustomerAccessoriesProvider
{
    public Card GetCard(Account account)
    {
        return new CreditCard
        {
            AccountId = account.AccountId,
            HolderId = account.CustomerId
        };
    }

    public Account GetAccount(int customerId)
    {
        return new CreditAccount
        {
            CustomerId = customerId
        };
    }
}

public class BusinessmanCustomerAccessoriesProvider : ICustomerAccessoriesProvider
{
    public Card GetCard(Account account)
    {
        return new CreditCard
        {
            AccountId = account.AccountId,
            HolderId = account.CustomerId
        };
    }

    public Account GetAccount(int customerId)
    {
        return new FeesFreeAccount
        {
            CustomerId = customerId
        };
    }
}

public class CreditCard : Card
{
}