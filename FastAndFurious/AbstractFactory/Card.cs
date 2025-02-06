namespace AbstractFactory;

public class Card
{
    public int CardId { get; set; }
    public CardType Type { get; set; }
    public int AccountId { get; set; }
    public int HolderId { get; set; }
}