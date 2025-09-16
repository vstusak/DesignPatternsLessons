namespace RepositoryPattern.Commands;

public interface ICommand
{
    void Execute();
    void UnDo();
    bool CanExecute();
}