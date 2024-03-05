using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    internal class CallFolders
    {
        public List<string> GetAllFiles(string rootFolder)
        {
            List<string> content = new List<string>();
            var directories = Directory.GetDirectories(rootFolder);

            content.AddRange(Directory.GetFiles(rootFolder));

           return content;
        }

        public List<string> GetAllDirectories(string rootFolder)
        {

            return Directory.GetDirectories(rootFolder).ToList();
             
        }


    }
}
