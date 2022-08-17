using VisitorPattern;
using VisitorPattern.Products;

var collector = new Collector();

var milan = new Cart();
var toy = new Toy { Name = "Bambitka", Price = 25 };
var book = new Book { Name = "Valka s mloky", Price = 199 };
var cpu = new Electronics { Name = "Intel Xeon", Price = 4599 };

milan.AddItem(toy);
milan.AddItem(book);
milan.AddItem(cpu);
milan.OrderItems();
collector.Collect(milan);

var tomik = new Cart();
var toy2 = new Toy { Name = "Plysacek", Price = 50 };
var book2 = new Book { Name = "Kamasutra", Price = 199 };
var cpu2 = new Electronics { Name = "Intel Pentium", Price = 499 };

tomik.AddItem(toy2);
tomik.AddItem(book2);
tomik.AddItem(cpu2);
tomik.OrderItems();
collector.Collect(tomik);

var peta = new Cart();
var toy3 = new Toy { Name = "Bublifuk", Price = 29 };
var book3 = new Book { Name = "Pan Prstenu", Price = 1499 };
var cpu3 = new Electronics { Name = "AMD Ryzen", Price = 3899 };

peta.AddItem(toy3);
peta.AddItem(book3);
peta.AddItem(cpu3);
peta.OrderItems();
collector.Collect(peta);

collector.GetReport();
