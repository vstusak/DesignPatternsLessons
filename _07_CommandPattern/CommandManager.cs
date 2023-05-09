public class CommandManager
{
    private readonly List<ICommand> _commands = new();

    public void RunCommand(ICommand command)
    {
        if (command.CanInvoke())
        {
            command.Invoke();
            _commands.Add(command);
        }
        else
        {
            command.ValidationMessage();
        }
    }

    public void Undo()
    {
        var lastCommand = _commands.LastOrDefault();
        
        if (lastCommand != null) 
        {
            lastCommand.Undo();
            //TODO - add remove
        }
    }

    public void Redo()
    {
        //TODO
    }
}