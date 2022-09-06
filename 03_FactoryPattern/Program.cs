using System;

namespace _03_FactoryPattern;

public static class Program
{
    public static void Main()
    {
        var cardType = CardType.Debit;
        var serviceType = BankServiceType.standard;

        //////////////////////////////////////
        ///Everything above comes from API./// 
        //////////////////////////////////////
        
        var card = CreateCardFactoryMethod(cardType);

        Console.WriteLine(card.ToString());

        //////////////////////////////////////

        var factoryCardType = CardType.Credit;
        var factory = new CardFactory();
        var factoryCard = factory.CreateCard(factoryCardType);

        Console.WriteLine(factoryCard.ToString());

        //////////////////////////////////////
        
        ///Get account object and card object based on serviceType service from API. 
        IBankServicesFactory bankServicesFactory = null;

        switch (serviceType)
        {
            case BankServiceType.standard:
                bankServicesFactory = new StandardBankServicesFactory();
                break;
            case BankServiceType.premium:   
                bankServicesFactory = new PremiumBankServicesFactory();
                break;
        }

        var card2 = bankServicesFactory.CreateCard();
        var account = bankServicesFactory.CreateAccount(false);
    }

    static ICard CreateCardFactoryMethod(CardType cardType)
    {
        ICard card = null;

        switch (cardType)
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