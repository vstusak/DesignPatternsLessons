namespace TemplateMethodPattern;

public class EudoraMailParser : MailParser
{
    protected override void AuthToServer()
    {
        Console.WriteLine("Auth to eudora server...");
    }

    protected override void LoadEmailsFromServer()
    {
        Console.WriteLine("Loading emails from eudora server...");
    }
}