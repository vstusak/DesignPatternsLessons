using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs
{
    public class ProductQuery
    {
        public Guid ProductId { get; }

        public ProductQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
