using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Handlers
{
    internal class Banknote5000Handler : Handler
    {
        private const int banknoteDenomination = 5000;

        public override void HandleRequest(int balanceToPay)
        {
            int NoOfBanknotes = balanceToPay / banknoteDenomination;
            Console.WriteLine($"We are paying out {NoOfBanknotes} × {banknoteDenomination} banknotes");
            base.HandleRequest(balanceToPay % banknoteDenomination);
        }
    }
}
