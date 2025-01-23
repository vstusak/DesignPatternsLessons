public class Card
{
    public int CardId { get; set; }
    public CardType Type { get; init; }
    public int AccountId { get; set; }
    public string HolderId { get; set; }
}

public class Account
{
    public int AccountId { get; set; }
    public AccountType Type { get; init; }
    public string HolderId { get; set; }
}

public enum CardType
{
    Credit,
    Debet
}

public enum AccountType
{
    Regular,
    Savings,
    Credit,
    FeesFree
}