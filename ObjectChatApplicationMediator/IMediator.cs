using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChatApplicationMediator
{
    public interface IMediator
    {
        void SendToAll(string from);

        void AddRecipient(IRecipient recipient);
    }
}
