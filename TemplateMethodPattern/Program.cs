// See https://aka.ms/new-console-template for more information

using TemplateMethodPattern;

Console.WriteLine("Hello, World!");
ExchangeMailParser exchangeMailParser = new();
exchangeMailParser.ProcessEmail();

EudoraMailParser eudoraMailParser = new();
eudoraMailParser.ProcessEmail();

ApacheMailParser apacheMailParser = new();
apacheMailParser.ProcessEmail();


