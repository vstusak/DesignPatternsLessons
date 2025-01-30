namespace AbstractFactory;

public class Card
{
    public int CardId { get; set; }
    public CardType Type { get; init; }
    public int AccountId { get; set; }
    public string HolderId { get; set; }
}