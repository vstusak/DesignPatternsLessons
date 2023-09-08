// See https://aka.ms/new-console-template for more information

using Castle.Windsor;
using ObjectChatApplicationMediator;
using ObjectChatApplicationMediator.Positions;


var container = new WindsorContainer();

var defaultInstaller = new ObjectChatApplicationInstaller();

var permissionInstaller = new ObjectPermissionChatApplicationInstaller();

container.Install(permissionInstaller);

Console.WriteLine("Hello, Mediator!");

var mediator = container.Resolve<IMediator>();

var worker1 = new Worker("Worker1", mediator);
var worker2 = new Worker("Worker2", mediator);
var dev = new Dev("Dev", mediator);
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