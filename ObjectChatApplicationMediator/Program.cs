// See https://aka.ms/new-console-template for more information

using ObjectChatApplicationMediator;
using ObjectChatApplicationMediator.Positions;

Console.WriteLine("Hello, World!");

var mediator = new Mediator();
var dev = new Dev(mediator);
mediator.AddRecipient(dev);


var ceo = new Ceo(mediator);

mediator.AddRecipient(ceo);

dev.SendToAll();
