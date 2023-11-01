using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    public class ExchangeMailParser
    {
        public void ProcessEmail()
        {
            ConnectToServer();
            AuthToServer();
            LoadEmailsFromServer();
            DistributeEmails();
        }

        public void ConnectToServer()
        {
            Console.WriteLine("Connecting to server...");
        }

        public void AuthToServer()
        {
            Console.WriteLine("Auth to exchange server...");
        }

        public void LoadEmailsFromServer()
        {
            Console.WriteLine("Loading emails from exchange server...");
        }

        public void DistributeEmails()
        {
            Console.WriteLine("Emails distribution...");
        }
    }
}
