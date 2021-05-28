namespace Factory.Cards
{
    public abstract class AbstractCard : ICard
    {
        public abstract string CardType { get; }

        public int CreditLimit { get; set; }

        protected AbstractCard(int creditLimit)
        {
            CreditLimit = creditLimit;
        }

        public override string ToString()
        {
            return $"Card Type: {CardType}; Credit limit: {CreditLimit}, type {GetType()}";
        }
    }
}
