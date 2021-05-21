using Factory.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    
    public class CardFactory
    {
        public ICard CreateCard(CardTypes cardType, int limit)
        {
            return cardType switch
            {
                CardTypes.Credit => new CreditCard(limit),
                CardTypes.Debit => new DebitCard(limit),
                _ => throw new NotImplementedException()
            };
        }
    }
}
