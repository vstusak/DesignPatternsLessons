namespace Factory.Cards
{
    public class DebitCard : AbstractCard
    {
        public override string CardType => "Debit card";

        public DebitCard(int creditLimit) : base(creditLimit)
        {
        }
    }
}
