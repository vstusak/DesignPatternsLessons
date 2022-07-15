namespace CommandPattern.Commands
{
    public interface IAcademyCommand
    {
        void Execute();
        bool CanExecute();
        //void Undo(); Does not comply with single responsibility to be replaced with memento design pattern.
    }
}