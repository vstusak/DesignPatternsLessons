// See https://aka.ms/new-console-template for more information

using BridgePattern;

Console.WriteLine("Hello, World!");

var detailView = new DetailView();


var product = new Book()
{
    Author = "Karl von Capek", Publisher = "Albatros", Title = "Valka s bloky",
    Price = 285
};

var PC = new Computer()
{
    Cpu = "Intel FOFO",
    Memory = "27MB",
    Name = "Devastator ++--",
    Price = 999,
    Gpu = "Matrox Prima Super Duper 666"
};

var bookAdapter = new BookAdapter(){Book = product};
detailView.Render(bookAdapter);

var listView = new ListView();
listView.Render(bookAdapter);

var computerAdapter = new ComputerAdapter() {Computer = PC};

detailView.Render(computerAdapter);
listView.Render(computerAdapter);
