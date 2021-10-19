using System;
using System.Collections.Generic;

namespace RepositoryPattern
{
    internal class CommandManager
    {
        private Stack<IAcademyCommand> _commads = new Stack<IAcademyCommand>();
        public CommandManager()
        {
           
        }

        public void Invoke(IAcademyCommand command)
        {

            if (command.CanExecute())
            {
                command.Execute();
                _commads.Push(command);
            }            
        }

        internal void Undo()
        {
            var lastCommand = _commads.Pop();
            lastCommand.Undo();
        }
    }
}