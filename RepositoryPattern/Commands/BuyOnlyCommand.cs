using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Commands
{
    public class BuyOnlyCommand : IOnlyCommand
    {
        public Guid ProductId { get; private set; }

        public BuyOnlyCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
