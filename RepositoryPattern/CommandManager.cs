namespace RepositoryPattern
{
    internal class CommandManager
    {
        public CommandManager()
        {
        }

        public void Invoke(IAcademyCommand command)
        {
            command.Execute();
        }
    }
}