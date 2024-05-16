using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBox
{
    internal class Search : IKeyWord
    {
        public void Execute()
        {
            Console.WriteLine("Text has been searched.");
        }
    }
}
