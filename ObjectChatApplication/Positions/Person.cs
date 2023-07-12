using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChatApplication.Positions
{
    public abstract class Person
    {
        public string Name { get; set; }
        public PositionType PositionType { get; set; }
        protected List<Person> AllRecipients = new();

        public void SentToAll()
        {
            foreach (var recipient in AllRecipients)
            {
                recipient.MessageReceived(Name);
            }
        }

        public void MessageReceived(string from)
        {
            Console.WriteLine($"I am {Name}. Message received from {from}.");
        }

        public void AddRecipient(Person recipient)
        {
            AllRecipients.Add(recipient);
        }
    }
}
