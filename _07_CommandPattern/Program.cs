CommandManager manager = new CommandManager();
OrderNotificator orderNotificator = new OrderNotificator();
IInventory inventory = new Inventory();


//////////////////////////////////////////////////////

var command = new OneClickBuyCommand(2, 5, orderNotificator, inventory);
manager.RunCommand(command);
