using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility2.Handlers
{
    public class CashHandler : Handler
    {
        int _cash;

        public CashHandler(int cash)
        {
            _cash = cash;
        }

        public override void Handle(int balanceToPay)
        {
            int count = balanceToPay / _cash;

            if(count > 0) 
            {
                Console.WriteLine($"{count}x {_cash}");
            }
            

            var rest = balanceToPay % _cash;

            if(rest > 0)
            {
                base.Handle(rest);
            }
            
        }
    }
}
