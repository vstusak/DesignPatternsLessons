using RepositoryPattern.Commands;

namespace RepositoryPattern;

public class CommandInvoker
{
    private readonly Stack<ICommand> _executedHistory = new();

    public void ExecuteCommand(ICommand command)
    {
        if (!command.CanExecute())
        {
            Console.WriteLine("It isn't possible to execute command");
            return;
        }
        command.Execute();
        _executedHistory.Push(command);
    }

    public void UnDo()
    {
        if (_executedHistory.TryPop(out var command))
        {
            command.UnDo();
        }
    }
}