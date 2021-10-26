namespace RepositoryPattern.Commands
{
    internal interface IAcademyCommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    }
}