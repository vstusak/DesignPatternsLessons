using CommandPattern.Commands;
using CommandPattern.Memento;
using RepositoryPattern;
using System;

namespace CommandPattern
{

    public class CommandManagerWithHistory
    {
        private readonly RepositoryCareTaker _repositoryCareTaker;
        private readonly CommandManager _commandManager;
        private readonly ProductRepository _productRepository;

        public CommandManagerWithHistory(RepositoryCareTaker repositoryCareTaker, CommandManager commandManager, ProductRepository productRepository)
        {
            _repositoryCareTaker = repositoryCareTaker;
            _commandManager = commandManager;
            _productRepository = productRepository;
        }

        public void Invoke(IAcademyCommand command)
        {
            _repositoryCareTaker.PushCurrentToHistory();
            _commandManager.Invoke(command);
            _repositoryCareTaker.SetNewCurrent(_productRepository.CreateMemento());
        }

        public void Undo()
        {
            if (_repositoryCareTaker.UndoCount > 0)
            {
                var previousState = _repositoryCareTaker.PopState();
                _repositoryCareTaker.SetNewCurrent(previousState);
                _productRepository.SetMemento(previousState);
            }
            else
            {
                Console.WriteLine("History of commands is empty");
            }
        }
    }
}