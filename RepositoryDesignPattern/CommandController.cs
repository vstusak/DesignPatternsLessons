using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RepositoryDesignPattern.Commands;

namespace RepositoryDesignPattern
{
    public class CommandController
    {
        //private readonly Stack<ICommand> _commandStack = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                command.Execute();
                //_commandStack.Push(command);
            }
            else
            {
                Console.WriteLine("Command is not executable.");
            }
        }

        // Undo is Obsolete; Will be moved to memento pattern.

        //public void Undo()
        //{
        //    if (_commandStack.TryPop(out var command))
        //    {
        //        command.Undo();
        //    }
        //    else
        //    {
        //        Console.WriteLine("No undo command left!");
        //    }
            
        //}
    }
}
