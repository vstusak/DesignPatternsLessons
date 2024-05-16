using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBox
{
    internal class NullKeyWord : IKeyWord
    {
        private string _name;
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
