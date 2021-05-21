using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Cards
{
    public interface ICard
    {
        string CardType { get; }
        int CreditLimit { get; }
    }

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
            return $"Card Type: {CardType}; Credit limit: {CreditLimit}";
        }
    }

    public class CreditCard : AbstractCard
    {
        public override string CardType => "Credit card";

        public CreditCard(int creditLimit) : base(creditLimit)
        {
        }
    }

    public class DebitCard : AbstractCard
    {
        public override string CardType => "Debit card";

        public DebitCard(int creditLimit) : base(creditLimit)
        {
        }
    }
}
