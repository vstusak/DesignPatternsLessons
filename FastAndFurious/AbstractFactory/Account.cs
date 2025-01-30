namespace AbstractFactory;

public class Account
{
    public int AccountId { get; set; }
    public AccountType Type { get; init; }
    public int CustomerId { get; set; }

}