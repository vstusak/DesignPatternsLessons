using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs
{
    public interface ICommandHandler<TCommand>
    {
        void Execute(TCommand command);
    }

    interface IBuyCommandHandler : ICommandHandler<BuyCommand>
    {
        
    }
}
