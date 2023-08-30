using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChatApplicationMediator
{
    public interface IMediator
    {
        void SendTo(string from, string to);

        void SendToAll(string from, Type fromType);

        void SendToGroup(string from, Type to);

        void AddRecipient(IRecipient recipient);
    }
}
