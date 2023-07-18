using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Handlers
{
    //It's here just to be first.
    internal class FirstHandler : Handler
    {
        public override int Order { get; }
        public override HandlerType HandlerType => HandlerType.FirstHandler; 

        public override void HandleRequest(int balanceToPay)
        {
            base.HandleRequest(balanceToPay);
        }
    }
}
