using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectChatApplicationMediator.Positions;

namespace ObjectChatApplicationMediator
{
    public class PermissionCheckProxyMediator : Mediator
    {
       
        //Limit worker to send only to your group and bellow (Worker x CEO, Lawyers; Dev x Lawyers)
        public override void SendToAll(string from, Type fromType)
        {

            //alternative - where and single for instead of  if
            //foreach (var recipient in
            //    CorrectedRecipients(from).Where(r =>
            //        fromType == typeof(Dev) && r.GetType() != typeof(Lawyer)
            //        || fromType == typeof(Worker) && r.GetType() != typeof(Lawyer) 
            //                                      && r.GetType() != typeof(Ceo))
            //    )
            //{
            //    SendMessage(from,recipient);
            //}
            

            //TODO rework to if-less version

            if (fromType == typeof(Dev))
            {
                foreach (var recipient in CorrectedRecipients(from).Where(r => r.GetType() != typeof(Lawyer)))
                {
                    SendMessage(from, recipient);
                }
            }

            else if (fromType == typeof(Worker)) 
            {
                foreach (var recipient in CorrectedRecipients(from)
                             .Where(r => r.GetType() != typeof(Lawyer) && r.GetType() != typeof(Ceo)))
                {
                    SendMessage(from, recipient);
                }
            }

            else
            {
                base.SendToAll(from, fromType);
            }
        
        }

    }
}
