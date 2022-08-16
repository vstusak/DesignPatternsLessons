namespace _03_FactoryPattern;

public static class Program
{
    public static void Main()
    {
        var cardType = CardType.Debit;

        var card = CreateCardFactoryMethod(cardType);

        Console.WriteLine(card.ToString());

        //////////////////////////////////////

        var factoryCardType = CardType.Credit;
        var factory = new CardFactory();
        var factoryCard = factory.CreateCard(factoryCardType);

        Console.WriteLine(factoryCard.ToString());
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