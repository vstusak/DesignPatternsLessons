using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RepositoryDesignPattern.Commands;
using RepositoryDesignPattern.Memento;

namespace RepositoryDesignPattern
{
    public class CommandControllerWithHistory
    {
        private readonly CommandController _controller;
        private readonly ProductRepositoryCareTaker _careTaker;

        public CommandControllerWithHistory(CommandController controller, ProductRepositoryCareTaker careTaker)
        {
            _controller = controller;
            _careTaker = careTaker;
        }

        public void Invoke(ICommand command)
        {
            _careTaker.Push();
            _controller.Invoke(command);
        }

        public void Undo()
        {
            _careTaker.Undo();
        }

        public void Redo()
        {
            _careTaker.Redo();
        }
    }
}
