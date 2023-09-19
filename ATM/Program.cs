﻿// See https://aka.ms/new-console-template for more information

using ATM;
using Castle.Windsor;

//var cashRegister = new CashRegister(
//    amountOf5000Banknotes: 10,
//    amountOf2000Banknotes: 0,
//    amountOf1000Banknotes: 1,
//    amountOf500Banknotes: 2,
//    amountOf200Banknotes: 10,
//    amountOf100Banknotes: 0);

// @TODO How to setup windsor container for resolve list of interfaces - RWS interview home work

var container = new WindsorContainer();
container.Install(new ATMInstaller());


//var exceptionChainsFactory = container.Resolve<IExceptionsChainsFactory>();
var bankNoteResource = container.Resolve<IBankNoteResource>();
var handlerChainFactory = container.Resolve<IHandlerChainFactory>();


const int amountToPay = 210000;
Console.WriteLine($"amount to pay {amountToPay}");
Console.WriteLine($"money in cash register {bankNoteResource.GetCashBalance()}");
var handler = handlerChainFactory.GetChain();
//IHandler handler = new AmountToPayValidationHandler(exceptionChainsFactory);
//handler.SetNext(new SumToPayValidationHandler(bankNoteResource, exceptionChainsFactory))
//    .SetNext(new BanknoteHandler(BankNote5000, bankNoteResource))
//    .SetNext(new BanknoteHandler(BankNote2000, bankNoteResource))
//    .SetNext(new BanknoteHandler(BankNote1000, bankNoteResource))
//    .SetNext(new BanknoteHandler(BankNote500, bankNoteResource))
//    .SetNext(new BanknoteHandler(BankNote200, bankNoteResource))
//    .SetNext(new BanknoteHandler(BankNote100, bankNoteResource));

handler.HandleRequest(amountToPay);

Console.ReadKey();