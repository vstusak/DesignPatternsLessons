// See https://aka.ms/new-console-template for more information
using ATM.Handlers;

int amountToPay = 1000000;
IHandler _handler = new AmountToPayValidationHandler();
_handler.SetNext(new Banknote5000Handler())
.SetNext(new Banknote2000Handler())
.SetNext(new Banknote1000Handler())
.SetNext(new Banknote500Handler())
.SetNext(new Banknote200Handler())
.SetNext(new Banknote100Handler());
_handler.HandleRequest(amountToPay);
