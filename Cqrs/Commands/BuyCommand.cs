using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs
{
    public class BuyCommand
    {
        public Guid ProductId { get; }

        public BuyCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
