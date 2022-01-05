using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RepositoryDesignPattern.Commands;

namespace RepositoryDesignPattern
{
    internal class CommandController
    {
        public async Task Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                await command.Execute();
            }
            else
            {
                Console.WriteLine("Command is not executable.");
            }
        }
    }
}
