namespace TemplateMethodPattern;

public class ApacheMailParser : MailParser
{
    protected override void AuthToServer()
    {
        Console.WriteLine("Auth to apache server...");
    }

    protected override void LoadEmailsFromServer()
    {
        Console.WriteLine("Loading emails from apache server...");
    }
}