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
            _repositoryCareTaker.PushCurrentToUndo();
            _commandManager.Invoke(command);
            _repositoryCareTaker.SetNewCurrent(_productRepository.CreateMemento());
            _repositoryCareTaker.ClearRedoStack();
        }

        public void Undo()
        {
            if (_repositoryCareTaker.UndoCount > 0)
            {
                _repositoryCareTaker.PushCurrentToRedo();
                var previousState = _repositoryCareTaker.PopUndoState();
                _repositoryCareTaker.SetNewCurrent(previousState);
                _productRepository.SetMemento(previousState);
            }
            else
            {
                Console.WriteLine("History of commands is empty");
            }
        }

        internal void Redo()
        {
            if (_repositoryCareTaker.RedoCount > 0)
            {
                _repositoryCareTaker.PushCurrentToUndo();
                var redoState = _repositoryCareTaker.PopRedoState();
                _repositoryCareTaker.SetNewCurrent(redoState);
                _productRepository.SetMemento(redoState);
            }
            else
            {
                Console.WriteLine("Redo of commands is empty");
            }
        }
    }
}