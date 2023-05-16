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
            var lastCommand = _commands.Pop();
            lastCommand.Undo();
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
            Console.WriteLine("There are no commands to undo.");
            //throw e;
            //TODO probrat poradne exception handling
        }

    }

    public void Redo()
    {
        //TODO
    }
}