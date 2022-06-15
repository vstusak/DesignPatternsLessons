// See https://aka.ms/new-console-template for more information

using BridgePattern;

Console.WriteLine("Hello, World!");

var detailView = new DetailView();


var product = new Book() {Author = "Karl von Capek", Publisher = "Albatros", Title = "Valka s bloky"};

detailView.Render(product);

var listView = new ListView();
listView.Render(product);