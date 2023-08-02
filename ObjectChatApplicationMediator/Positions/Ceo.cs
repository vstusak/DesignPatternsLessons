using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectChatApplicationMediator.Positions
{
    public class Ceo
    {
        private IMediator _mediator;
        public Ceo(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void ReactToMessage(string from)
        {
            Console.WriteLine($"I am {GetType()}. Message received from {from}.");
        }
    }
}
