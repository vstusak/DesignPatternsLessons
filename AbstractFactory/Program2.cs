using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program2
    {
        static void Main(string[] args)
        {
            var bankFactory = new BankFactory();
            var bankServicesFactory = bankFactory.CreateBankServicesFactory(ServiceType.P);
            Card card = bankServicesFactory.CreateCard();
            Account account = bankServicesFactory.CreateAccount();
            Insurance insurance = bankServicesFactory.CreateInsurance();

            Console.WriteLine($"{account.ToString()} with {card.ToString()} created and is covered by {insurance.ToString()}.");
            Console.ReadLine();
        }
    }

    interface IBankServicesFactory
    {
        Card CreateCard();
        Account CreateAccount();
        
        Insurance CreateInsurance();
    }

    class PremiumBankServicesFactory : IBankServicesFactory
    {
        public Card CreateCard()
        {
            return new CreditCard(200);
        }

        public Account CreateAccount()
        {
            return new SavingsAccount();
        }

        public Insurance CreateInsurance()
        {
            return new LifeInsurance();
        }
    }

    class FreeBankServicesFactory : IBankServicesFactory
    {
        public Card CreateCard()
        {
            return new DebitCard();
        }

        public Account CreateAccount()
        {
            //return new
            return new RegularAccount();
        }

        public Insurance CreateInsurance()
        {
            return new CarInsurance();
        }
    }

    abstract class Account
    {
    }
}
