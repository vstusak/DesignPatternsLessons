using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Cards;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //from parameter
            var type = CardTypes.Credit;
            ICard cardNoFactory;

            cardNoFactory = type switch
            {
                CardTypes.Credit => new CreditCard(1000),
                CardTypes.Debit => new DebitCard(-1),
                _ => throw new NotImplementedException()
            };


            Console.WriteLine(cardNoFactory);
            //Console.WriteLine(card2);
            //----------------------------------------------------------------------------------------------

            //with Factory pattern:
            var cardFactory = new CardFactory();

            ICard card1 = cardFactory.CreateCard(CardTypes.Credit, 1000);
            ICard card2 = cardFactory.CreateCard(CardTypes.Debit, -1);

            Console.WriteLine(card1);
            Console.WriteLine(card2);

        }
    }
}
