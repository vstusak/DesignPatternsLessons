using RepositoryPattern.Memento;
using System;
using System.Collections.Generic;

namespace CommandPattern.Memento
{
    public class RepositoryCareTaker
    {
        private Stack<ProductRepositoryMemento> UndoStates { get; set; } = new();
        private Stack<ProductRepositoryMemento> RedoStates { get; set; } = new();
        private ProductRepositoryMemento CurrentState { get; set; }

        public int UndoCount => UndoStates.Count;
        public int RedoCount => RedoStates.Count;

        public void PushCurrentToUndo()
        {
            // first calling of this method before SetNewCurrent will save null
            if (CurrentState != null)
            {
                UndoStates.Push(CurrentState);
            }
        }

        public void SetNewCurrent(ProductRepositoryMemento productRepositoryMemento)
        {
            CurrentState = productRepositoryMemento;
        }

        public ProductRepositoryMemento PopUndoState()
        {
            return UndoStates.Pop();
        }

        public void ClearRedoStack()
        {
            RedoStates.Clear();
        }

        public ProductRepositoryMemento PopRedoState()
        {
            return RedoStates.Pop();
        }

        internal void PushCurrentToRedo()
        {
            if (CurrentState != null)
            {
                RedoStates.Push(CurrentState);
            }
        }
    }
}