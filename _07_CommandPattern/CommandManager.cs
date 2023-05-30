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
            //throw e;
            //throw;
            var excpt = new KonecSvetaException("Nevyšlo to", e);
            excpt.ErrorCode = -1;
            throw excpt;
            //TODO probrat poradne exception handling
            //TODO vyzkouset naimplementovat vlastni exception
        }
        finally
        {
            Console.WriteLine("Jsme ve Finally");
        }
        Console.WriteLine("Jsme za Finally");
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


public class KonecSvetaException : Exception
{
    public int ErrorCode { get; set; }
    public KonecSvetaException()
    {
        
    }
    public KonecSvetaException(string message) : base(message)
    {
        
    }
    public KonecSvetaException(string message, Exception inner) : base(message, inner)
    {
        
    }
}