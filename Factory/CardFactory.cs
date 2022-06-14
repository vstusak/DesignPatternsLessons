using Factory.Cards;
using FactoryPattern.Accounts;
using System;

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

    public interface IBankServicesFactory
    {
        ICard GetCard();
        IAccount GetAccount();
    }

    public class FreeBankServicesFactory : IBankServicesFactory
    {
        public IAccount GetAccount()
        {
            return new CheckingsAccount();
        }

        public ICard GetCard()
        {
            return new DebitCard(1000);
        }
    }

    public class PremiumBankServicesFactory : IBankServicesFactory
    {
        public IAccount GetAccount()
        {
            return new SavingsAccount();
        }

        public ICard GetCard()
        {
            return new CreditCard(-1);
        }
    }

    public class BankServiceFactoryFactory
    {
        public IBankServicesFactory CreateBankServicesFactory(BankServiceTypes bankServiceTypes)
        {
            switch (bankServiceTypes)
            {
                case BankServiceTypes.Free : return new FreeBankServicesFactory();
                case BankServiceTypes.Premium: return new PremiumBankServicesFactory();
                default: throw new NotImplementedException();
            }
                
        }
    }

    

}
