using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChatApplicationMediator
{
    public class Mediator: IMediator 
    {
        protected List<IRecipient> AllRecipients = new();

        public void SendToAll(string from)
        {
            foreach (var recipient in AllRecipients)
            {
                recipient.ReactToMessage(from);
            }
        }

        public void AddRecipient(IRecipient recipient)
        {
            AllRecipients.Add(recipient);
        }
    }
}
