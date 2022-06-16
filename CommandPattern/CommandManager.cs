using CommandPattern.Commands;

namespace CommandPattern
{
    internal class CommandManager
    {
        //private readonly Stack<IAcademyCommand> _commads = new();
        public CommandManager()
        {

        }

        public void Invoke(IAcademyCommand command)
        {

            if (command.CanExecute())
            {
                command.Execute();
               // _commads.Push(command);
            }
        }

        //public void Invoke(ICommandHandler command)
        //{
        //    command.Execute();
        //}

        internal void Undo()
        {
            //var lastCommand = _commads.Pop();
            //lastCommand.Undo();
        }
    }
}