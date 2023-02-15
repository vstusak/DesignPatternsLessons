using ChainOfResponsibility2.Handlers;

var handler = new CashHandler(5000);
handler.SetNext(new CashHandler(2000))
    .SetNext(new CashHandler(1000))
    .SetNext(new CashHandler(500))
    .SetNext(new CashHandler(200))
    .SetNext(new CashHandler(100));

handler.Handle(000);
