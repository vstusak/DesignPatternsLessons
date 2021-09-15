using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new CardFactory().CreateCard(CardType.Debit);
        }
    }

    internal class CardFactory
    {
        public Card CreateCard(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Debit:
                    return new DebitCard();
                case CardType.Credit:
                    return new CreditCard(1000);
                default:
                    throw new ArgumentOutOfRangeException(nameof(cardType), cardType, null);
            }
        }
    }

    internal class CreditCard : Card
    {
        private int Limit { get; set; }
        public override void TakeMoney(int amount)
        {
            if (amount <= Limit)
            {
                Limit -= amount;
            }
            else
            {
                throw new Exception("Limit overreached.");
            }
        }

        public CreditCard(int limit)
        {
            Limit = limit;
        }
    }

    internal class DebitCard : Card
    {
        public override void TakeMoney(int amount)
        {
            throw new NotImplementedException();
        }
    }

    internal abstract class Card
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Ccv { get; set; }

        public abstract void TakeMoney(int amount);
    }

    internal enum CardType
    {
        Debit,
        Credit
    }
}
