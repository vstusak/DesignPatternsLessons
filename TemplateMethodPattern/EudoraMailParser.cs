using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    public class EudoraMailParser
    {
        public void ProcessEmail()
        {
            Console.WriteLine("Connecting to server...");
            Console.WriteLine("Auth to eudora server...");
            Console.WriteLine("Loading emails from eudora server...");
            Console.WriteLine("Emails distribution...");
        }
    }
}
