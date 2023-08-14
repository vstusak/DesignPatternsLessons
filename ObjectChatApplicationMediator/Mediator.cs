using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectChatApplicationMediator.Positions;

namespace ObjectChatApplicationMediator
{
    public class Mediator: IMediator, IMediatorDev, IMediatorWorker
    {
        protected List<IRecipient> AllRecipients = new();
        
        //protected Dictionary<string, IRecipient> AllRecipients = new();
        
        //Limit worker to send only to your group and bellow (Worker x CEO, Lawyers; Dev x Lawyers)
        private IEnumerable<IRecipient> CorrectedRecipients(string name) => AllRecipients.Where(r=>r.Name != name);

        public void SendToAll(string from)
        {
            foreach (var recipient in CorrectedRecipients(from))
            {
                recipient.ReactToMessage(from);
            }
        }

        public void SendToGroup(string from, Type to)
        {
            foreach (var recipient in CorrectedRecipients(from).Where(r=>r.GetType() == to))
            {
                recipient.ReactToMessage(from);
            }
        }

        void IMediatorDev.SendToAll(string from)
        {
            foreach (var recipient in CorrectedRecipients(from).Where(r=>r.GetType() != typeof(Lawyer)))
            {
                recipient.ReactToMessage(from);
            }
        }

        void IMediatorWorker.SendToAll(string from)
        {
            foreach (var recipient in CorrectedRecipients(from).Where(r=>r.GetType() != typeof(Lawyer) && r.GetType() != typeof(Ceo)))
            {
                recipient.ReactToMessage(from);
            }
        }

        public void AddRecipient(IRecipient recipient)
        {
            AllRecipients.Add(recipient);
        }

        public void SendTo(string from, string to)
        {
            var recipient = AllRecipients.FirstOrDefault(r => r.Name == to);
            recipient?.ReactToMessage(from);
        }
    }
}
