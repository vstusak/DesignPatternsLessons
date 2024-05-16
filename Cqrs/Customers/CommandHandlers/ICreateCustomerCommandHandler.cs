using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Customers.Commands;

namespace CQRS.Customers.CommandHandlers
{
    public interface ICreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
    }
}
