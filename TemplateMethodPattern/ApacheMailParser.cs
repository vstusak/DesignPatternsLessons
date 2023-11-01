using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    public class ApacheMailParser
    {
        public void ProcessEmail()
        {
            Console.WriteLine("Connecting to server...");
            Console.WriteLine("Auth to apache server...");
            Console.WriteLine("Loading emails from apache server...");
            Console.WriteLine("Emails distribution...");
        }
    }
}
