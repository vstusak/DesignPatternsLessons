public class CommandManager
{
    public void RunCommand(ICommand command)
    {
        command.Invoke();
    }
}