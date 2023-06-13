CommandManager manager = new CommandManager();
OrderNotificator orderNotificator = new OrderNotificator();
IInventory inventory = new Inventory();

var command = new OneClickBuyCommand(2, 5, orderNotificator, inventory);
manager.RunCommand(command);
Console.WriteLine($"ProductCount for productId 2 is: [{inventory.GetProduct(2).Amount}]");


var command2 = new OneClickBuyCommand(1, 6, orderNotificator, inventory);
manager.RunCommand(command2);
Console.WriteLine($"ProductCount for productId 2 is: [{inventory.GetProduct(2).Amount}]");

//TODO add functionality to 'return back' (undo)
var productId = 2;

var productCount = inventory.GetProduct(productId).Amount;
Console.WriteLine($"ProductCount for product [{productId}] before Undo: [{productCount}]");

manager.Undo();
Console.WriteLine($"ProductCount for productId 2 is: [{inventory.GetProduct(2).Amount}]");
//manager.Undo();
//manager.Undo();
//manager.Undo();
//manager.Undo();

var productCountAfter = inventory.GetProduct(productId).Amount;
Console.WriteLine($"ProductCount for productId 2 is: [{inventory.GetProduct(2).Amount}]");

manager.Redo();
Console.WriteLine($"ProductCount for productId 2 is: [{inventory.GetProduct(2).Amount}]");

manager.Undo();
Console.WriteLine($"ProductCount for productId 2 is: [{inventory.GetProduct(2).Amount}]");

var command3 = new OneClickBuyCommand(2, 10, orderNotificator, inventory);
manager.RunCommand(command3);
Console.WriteLine($"ProductCount for productId 2 is: [{inventory.GetProduct(2).Amount}]");

//try
//{
//	manager.Undo();
//}
//catch (KonecSvetaException e) when (e.ErrorCode == -2)
//{ 
//Console.WriteLine(e.ErrorCode);
//}
//catch (Exception e)
//{
//	Console.WriteLine(e.StackTrace);
//}
//finally
//{
//	Console.WriteLine();
//}