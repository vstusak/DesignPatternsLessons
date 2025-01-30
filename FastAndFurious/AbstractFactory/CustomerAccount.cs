namespace AbstractFactory;

public class CustomerAccount
{
    public Card Card { get; set; }
    public Account Account { get; set; }
    public Customer Customer { get; set; }
}