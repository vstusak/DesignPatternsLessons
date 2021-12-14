using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet
{
    public static class PaymentService
    {
        public static bool Pay()
        {
            Random rnd = new Random(DateTime.Now.Second);
            var restult =  rnd.Next(0, 1);
            if (restult == 0) 
            { return false; }
            else
            {
                return true;
            }
        }
    }
}
