namespace AbstractFactory;

public class Program2
{
    public static void Main()
    {
        var customer = new Customer
        {
            CustomerType = CustomerType.Regular,
            Name = "Pepa",
            CustomerId = 1,
        };

        var account = GetAccount(customer.CustomerType, customer.CustomerId);

        var card = GetCard(customer.CustomerType, account);

        var customerAccount = new CustomerAccount
        {
            Account = account,
            Card = card,
            Customer = customer
        };

        Account GetAccount(CustomerType customerType, int customerId)
        {
            var account = new Account
            {
                AccountId = 1,
                CustomerId = customerId,
            };

            switch (customerType)
            {
                case CustomerType.Regular:
                    account.Type = AccountType.Regular;
                    break;
                case CustomerType.Authorized:
                    account.Type = AccountType.Credit;
                    break;
                case CustomerType.Businessman:
                    account.Type = AccountType.FeesFree;
                    break;
                case CustomerType.Undefined:
                default:
                    throw new ArgumentOutOfRangeException(nameof(customerType), customerType, null);
            }

            return account;
        }

        Card GetCard(CustomerType customerType, Account account)
        {
            if (account.Type == AccountType.Savings)
            {
                throw new NotSupportedException("Savings account type does not support cards.");
            }

            var card = new Card
            {
                CardId = 1,
                AccountId = account.AccountId,
                HolderId = account.CustomerId,
            };

            card.Type = customerType switch
            {
                CustomerType.Regular when account.Type == AccountType.Regular => CardType.Debet,
                CustomerType.Authorized => CardType.Credit,
                CustomerType.Businessman => CardType.Credit,
                CustomerType.Undefined => throw new ArgumentOutOfRangeException(nameof(customerType), customerType, null),
                _ => throw new ArgumentOutOfRangeException(nameof(customerType), customerType, null)
            };

            return card;
        }
    }
}