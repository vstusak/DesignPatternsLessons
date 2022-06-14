namespace Factory.Cards
{
    public interface ICard
    {
        string CardType { get; }
        int CreditLimit { get; }
    }
}
