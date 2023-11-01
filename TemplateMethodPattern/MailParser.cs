using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    abstract class MailParser
    {
        public void ConnectToServer()
        {
            Console.WriteLine("Connecting to server...");
        }

        public abstract void AuthToServer();

        public abstract void LoadEmailsFromServer();

        public void DistributeEmails()
        {
            Console.WriteLine("Emails distribution...");
        }
    }
}
