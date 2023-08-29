// See https://aka.ms/new-console-template for more information
//Mediator pattern could be useful for central managing of references.
//OR keep references in each object???

using CompanyChat;

var mediator = new Mediator();
var ceo = new CEO(mediator);
mediator.AddRecipient(ceo);
mediator.AddRecipient(new Developer(mediator));
mediator.AddRecipient(new Manager(mediator));
mediator.AddRecipient(new Worker(mediator));

ceo.SendMessage("Testing message");

// CEO, Developer, Manager, Worker