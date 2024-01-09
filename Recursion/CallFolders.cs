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
            
            content.AddRange(Directory.GetFiles(rootFolder));

            var directories = Directory.GetDirectories(rootFolder);

            foreach (var directory in directories)
            {
                content.AddRange(GetAllFiles(directory));
            }



           return content;
        }

        //public List<string> GetAllDirectories(string rootFolder)
        //{

        //    return Directory.GetDirectories(rootFolder).ToList();
             
        //}


    }
}
