using _03_FactoryPattern.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_FactoryPattern
{
    public interface IBankServicesFactory
    {
        ICard CreateCard();
        IAccount CreateAccount(bool isFree);
    }

    public class StandardBankServicesFactory : IBankServicesFactory
    {
        public IAccount CreateAccount(bool isFree)
        {
            var account = new PaidAccount();
            account.IsFree = isFree;
            return account;
        }

        public ICard CreateCard()
        {
            return new DebitCard();
        }
    }

    public class PremiumBankServicesFactory : IBankServicesFactory
    {
        public IAccount CreateAccount(bool isFree)
        {
            var account = new FreeAccount();
            account.IsFree = isFree;
            return account;
        }

        public ICard CreateCard()
        {
            return new CreditCard();
        }
    }
}
