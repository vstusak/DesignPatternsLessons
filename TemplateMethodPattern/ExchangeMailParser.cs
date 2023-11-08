namespace TemplateMethodPattern;

public class ExchangeMailParser : MailParser
{
    protected override void AuthToServer()
    {
        Console.WriteLine("Auth to exchange server...");
    }

    protected override void LoadEmailsFromServer()
    {
        Console.WriteLine("Loading emails from exchange server...");
    }
}