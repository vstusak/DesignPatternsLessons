using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility2.Handlers
{
    public interface IAtmFactory
    {
        IHandler GetChain();
    }

    class AtmFactory : IAtmFactory
    {
        xxx;
        public AtmFactory()
        {
            
        }
        public IHandler GetChain()
        {
            throw new NotImplementedException();
        }
    }
}
