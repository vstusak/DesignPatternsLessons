// See https://aka.ms/new-console-template for more information

using ATM;
using ATM.Handlers;
using static ATM.BankNotesDenomination;
//TODO: implement this using BankNoteResource
var cashRegister = new CashRegister(
    amountOf5000Banknotes: 10,
    amountOf2000Banknotes: 0,
    amountOf1000Banknotes: 1,
    amountOf500Banknotes: 2,
    amountOf200Banknotes: 10,
    amountOf100Banknotes: 0);

// TODO fixme, I am broken
const int amountToPay = 2100;
Console.WriteLine( $"amount to pay {amountToPay}");
Console.WriteLine($"money in chash register {cashRegister.GetCashBalance()}");
IHandler _handler = new AmountToPayValidationHandler();
_handler.SetNext(new SumToPayValidationHandler(cashRegister))
    .SetNext(new BanknoteHandler(BankNote5000, cashRegister))
    .SetNext(new BanknoteHandler(BankNote2000, cashRegister))
    .SetNext(new BanknoteHandler(BankNote1000, cashRegister))
    .SetNext(new BanknoteHandler(BankNote500, cashRegister))
    .SetNext(new BanknoteHandler(BankNote200, cashRegister))
    .SetNext(new BanknoteHandler(BankNote100, cashRegister));

_handler.HandleRequest(amountToPay);

Console.ReadKey();