CommandManager manager = new CommandManager();
OrderNotificator orderNotificator = new OrderNotificator();
IInventory inventory = new Inventory();

//////////////////////////////////////////////////////

var command = new OneClickBuyCommand(2, 5, orderNotificator, inventory);
manager.RunCommand(command);

var command2 = new OneClickBuyCommand(1, 6, orderNotificator, inventory);
manager.RunCommand(command2);

//TODO add functionality to 'return back' (undo)
var productId = 2;

var productCount = inventory.GetProduct(productId).Amount;
Console.WriteLine($"ProductCount for product [{productId}] before Undo: [{productCount}]");

manager.Undo();
manager.Undo();
manager.Undo();
manager.Undo();
manager.Undo();

var productCountAfter = inventory.GetProduct(productId).Amount;
Console.WriteLine($"ProductCount for product [{productId}] after Undo: [{productCountAfter}]");
