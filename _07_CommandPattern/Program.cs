CommandManager manager = new CommandManager();
OrderNotificator orderNotificator = new OrderNotificator();
IInventory inventory = new Inventory();

//////////////////////////////////////////////////////

var command = new OneClickBuyCommand(2, 5, orderNotificator, inventory);
manager.RunCommand(command);

var command2 = new OneClickBuyCommand(1, 6, orderNotificator, inventory);
manager.RunCommand(command2);

//TODO add functionality to 'return back' (undo)