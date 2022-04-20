using System.Threading.Tasks;

namespace RepositoryDesignPattern.Commands
{
    internal interface ICommand
    {
        bool CanExecute();
        void Execute();
        void Undo();
    }
}
