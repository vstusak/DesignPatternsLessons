public class CommandManager
{
    private readonly Stack<ICommand> _undo = new();
    private readonly Stack<ICommand> _redo = new();

    public void RunCommand(ICommand command)
    {
        if (command.CanInvoke())
        {
            command.Invoke();
            _undo.Push(command);
            _redo.Clear();
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
            var lastCommand = _undo.Pop();
            //var lastCommand = ExtraUndo();
            lastCommand.Undo();
            _redo.Push(lastCommand);
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
        }
        finally
        {
            Console.WriteLine("Jsme ve Finally");
        }
        Console.WriteLine("Jsme za Finally");
    }

    public ICommand ExtraUndo()
    {
        return _undo.Pop();
    }

    public void Redo()
    {
        var lastCommand = _redo.Pop();
        lastCommand.Invoke();
        _undo.Push(lastCommand);
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