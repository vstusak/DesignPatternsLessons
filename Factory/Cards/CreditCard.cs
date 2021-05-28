namespace Factory.Cards
{
    public class CreditCard : AbstractCard
    {
        public override string CardType => "Credit card";

        public CreditCard(int creditLimit) : base(creditLimit)
        {
        }
    }
}
