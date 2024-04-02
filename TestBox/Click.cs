using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBox
{
    internal class Click : IKeyWord
    {
        public void Execute()
        {
            Console.WriteLine("Element was clicked.");
        }
    }
}
