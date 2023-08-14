using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectChatApplicationMediator.Positions
{
    public class Ceo:IRecipient
    {
        private IMediator _mediator;
        public string Name { get; set; }


        public Ceo(string name, IMediator mediator)
        {
            Name = name;
            _mediator = mediator;
        }

        public void ReactToMessage(string from)
        {
            Console.WriteLine($"I am {GetType().Name}. Message received from {from}.");
        }

        public void SendToAll()
        {
            _mediator.SendToAll(GetType().Name);
        }

        public void SendTo(string to)
        {
            _mediator.SendTo(Name, to);
        }

        public void SendToGroup(Type to)
        {
            _mediator.SendToGroup(Name, to);
        }
    }
}
