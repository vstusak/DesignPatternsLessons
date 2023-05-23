public class CommandManager
{
    private readonly Stack<ICommand> _commands = new();

    public void RunCommand(ICommand command)
    {
        if (command.CanInvoke())
        {
            command.Invoke();
            _commands.Push(command);
        }
        else
        {
            command.ValidationMessage();
        }

    }

    public void Undo()
    {
        try
        {
            //var lastCommand = _commands.Pop();
            var lastCommand = ExtraUndo();
            lastCommand.Undo();
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
            Console.WriteLine("There are no commands to undo.");
            throw e;
            //throw;
            //throw new NotImplementedException();
            //TODO probrat poradne exception handling
            //TODO vyzkouset naimplementovat vlastni exception
        }

    }

    public ICommand ExtraUndo()
    {
        return _commands.Pop();
    }

    public void Redo()
    {
        //TODO
    }
}