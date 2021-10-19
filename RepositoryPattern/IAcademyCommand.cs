namespace RepositoryPattern
{
    internal interface IAcademyCommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    }
}