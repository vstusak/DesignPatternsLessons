// See https://aka.ms/new-console-template for more information

using ObjectChatApplication.Positions;

//CEO, leader, worker, accountant, dev, test, sales, lawyers
var ceo = new Ceo("Petr Pucek");


var leader = new Leader("Richard Ondrejka");

ceo.AddRecipient(leader);
leader.AddRecipient(ceo);

var worker = new Worker("Tom Fulajtar");

ceo.AddRecipient(worker);
leader.AddRecipient(worker);
worker.AddRecipient(ceo);
worker.AddRecipient(leader);

ceo.SentToAll();

