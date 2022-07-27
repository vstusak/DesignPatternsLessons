using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet
{
    public class PaymentService : IPaymentService
    {
        public bool Pay()
        {
            Random rnd = new Random(DateTime.Now.Second);
            var result = rnd.Next(0, 2);
            return result != 0;
        }
    }

    public interface IPaymentService
    {
        bool Pay();
    }
}
