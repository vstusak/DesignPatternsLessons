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
        public Ceo(IMediator mediator)
        {
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
    }
}
