using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class ExpensiveResult
    {
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
