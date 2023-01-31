using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Handlers
{
    internal class AmountToPayValidationHandler : Handler
    {
        public override void HandleRequest(int balanceToPay)
        {
            if (balanceToPay % 100 != 0) 
            {
                Console.WriteLine("The requested amount is not valid. It must be devidible by 100.");
                return; 
            }
            base.HandleRequest(balanceToPay);
        }
    }
}
