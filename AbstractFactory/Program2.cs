using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program2
    {
        void Main(string[] args)
        {
            var bankServicesFactory = new FreeBankServicesFactory();
            var card = bankServicesFactory.CreateCard();
            var account = bankServicesFactory.CreateAccount();
        }
    }

    interface IBankServicesFactory
    {
        Card CreateCard();
        Account CreateAccount();
    }

    class PremiumBankServicesFactory : IBankServicesFactory
    {
        public Card CreateCard()
        {
            throw new NotImplementedException();
        }

        public Account CreateAccount()
        {
            throw new NotImplementedException();
        }
    }

    class FreeBankServicesFactory : IBankServicesFactory
    {
        public Card CreateCard()
        {
            throw new NotImplementedException();
        }

        public Account CreateAccount()
        {
            throw new NotImplementedException();
        }
    }

    abstract class Account
    {
    }
}
