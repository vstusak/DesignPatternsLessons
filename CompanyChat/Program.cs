// See https://aka.ms/new-console-template for more information
//Mediator pattern could be useful for central managing of references.
//OR keep references in each object???

using Castle.Windsor;
using CompanyChat;

var container = new WindsorContainer();
container.Install(new CompanyChatInstaller());

var mediator = container.Resolve<IMediator>();
var ceo = new CEO(mediator);
var dev = new Developer(mediator);
mediator.AddRecipient(ceo);
mediator.AddRecipient(dev);
mediator.AddRecipient(new Developer(mediator));
mediator.AddRecipient(new Developer(mediator));
mediator.AddRecipient(new Manager(mediator));
var worker = new Worker(mediator);
mediator.AddRecipient(worker);

worker.SendMessageToAll("from worker to all");
//dev.SendMessageToAll("from dev to all");
//ceo.SendMessageToAll("from ceo to all");

//ceo.SendMessage("Testing message");

//ceo.SendMessageToGroup<Developer>("Work!");

// CEO, Developer, Manager, Worker

// ToDo implement Proxy pattern for mediator
