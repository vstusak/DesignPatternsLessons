namespace CommandPattern.Commands
{
    public interface ICommandHandler
    {
        void Execute(BuyOnlyCommand command);
    }
}