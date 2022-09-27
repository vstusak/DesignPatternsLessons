using System.Threading.Tasks;

namespace RepositoryDesignPattern.Commands
{
    public interface ICommand
    {
        bool CanExecute();
        void Execute();
        void Undo();
    }
}
