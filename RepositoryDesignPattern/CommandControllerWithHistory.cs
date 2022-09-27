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
            _controller.Invoke(command);
            //TODO: Call CareTaker
        }

        public void Undo()
        {
            //TODO: Call CareTaker
        }
    }
}
