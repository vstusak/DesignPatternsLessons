// See https://aka.ms/new-console-template for more information

using ObjectChatApplicationMediator;
using ObjectChatApplicationMediator.Positions;

Console.WriteLine("Hello, Mediator!");

IMediator mediator = new Mediator();

//TODO: Apply proxy pattern for permissions

var worker1 = new Worker("Worker1", (IMediatorWorker)mediator);
var worker2 = new Worker("Worker2", (IMediatorWorker)mediator);
var dev = new Dev("Dev", (IMediatorDev)mediator);
var ceo = new Ceo("Ceo", mediator);
var lawyer = new Lawyer("Lawyer", mediator);

mediator.AddRecipient(worker1);
mediator.AddRecipient(worker2);
mediator.AddRecipient(dev);
mediator.AddRecipient(ceo);
mediator.AddRecipient(lawyer);

dev.SendToAll();
worker1.SendToAll();
ceo.SendToAll();

//Private messages
//Not to send messages to itself

dev.SendTo("Dev");
worker1.SendTo("Dev");

//Send to limited group

worker1.SendToGroup(typeof(Lawyer));
lawyer.SendToGroup(typeof(Worker));

