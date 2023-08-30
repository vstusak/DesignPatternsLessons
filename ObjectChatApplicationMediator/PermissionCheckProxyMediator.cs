using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectChatApplicationMediator.Positions;

namespace ObjectChatApplicationMediator
{
    public class PermissionCheckProxyMediator : IMediator
    {
        private readonly IMediator _mediator;

        public PermissionCheckProxyMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void SendTo(string from, string to)
        {
            _mediator.SendTo(from, to);
        }

        public void SendToAll(string from, Type fromType)
        {
            var devType = typeof(Dev);
            switch (fromType)
            {
                case devType:
                    break;
            }
        }

        public void SendToGroup(string from, Type to)
        {
            _mediator.SendToGroup(from, to);
        }

        public void AddRecipient(IRecipient recipient)
        {
            _mediator.AddRecipient(recipient);
        }
    }
}
