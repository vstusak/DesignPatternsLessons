using Microsoft.VisualBasic;

namespace _03_FactoryPattern
{
    internal class CardFactory
    {
        public CardFactory()
        {
        }

        internal ICard CreateCard(CardType factoryCardType)
        {
            ICard card = null;

            switch (factoryCardType)
            {
                case CardType.Credit:
                    card = new CreditCard();
                    break;
                case CardType.Debit:
                    card = new DebitCard();
                    break;
                default:
                    break;
            }

            return card;
        }
    }
}