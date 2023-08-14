using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChatApplicationMediator
{
    public interface IMediatorDev
    {
        void SendTo(string from, string to);

        void SendToGroup(string from, Type to);

        void SendToAll(string from);
    }
}
