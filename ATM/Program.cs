// See https://aka.ms/new-console-template for more information

using ATM;
using ATM.Handlers;

var cashRegister = new CashRegister(10,10,10,10,10,0);
int amountToPay = 2100;
IHandler _handler = new AmountToPayValidationHandler();
_handler.SetNext(new SumToPayValidationHandler(cashRegister))
    .SetNext(new BanknoteHandler(5000, cashRegister))
    .SetNext(new BanknoteHandler(2000, cashRegister))
    .SetNext(new BanknoteHandler(1000, cashRegister))
    .SetNext(new BanknoteHandler(500, cashRegister))
    .SetNext(new BanknoteHandler(200, cashRegister))
    .SetNext(new BanknoteHandler(100, cashRegister));
_handler.HandleRequest(amountToPay);
