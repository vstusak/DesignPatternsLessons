namespace RepositoryPattern.Commands
{
    public interface ICommandHandler
    {
        void Execute(BuyOnlyCommand command);
    }
}