using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodPattern
{
    public abstract class MailParser
    {
        protected void ConnectToServer()
        {
            Console.WriteLine("Connecting to server...");
        }

        protected abstract void AuthToServer();

        protected abstract void LoadEmailsFromServer();

        protected void DistributeEmails()
        {
            Console.WriteLine("Emails distribution...");
        }

        public void ProcessEmail()
        {
            ConnectToServer();
            AuthToServer();
            LoadEmailsFromServer();
            DistributeEmails();
        }
    }
}
