public class CommandManager
{
    public void RunCommand(ICommand command)
    {
        if (command.CanInvoke())
        {
            command.Invoke();
        }
        else
        {
            command.ValidationMessage();
        }
    }
}