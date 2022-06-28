using RepositoryPattern.Memento;

namespace CommandPattern.Memento
{
    internal class RepositoryCareTaker
    {
        private Stack<ProductRepositoryMemento> OldStates { get; set; } = new();
        private ProductRepositoryMemento CurrentState { get; set; }

        internal void PushCurrentToHistory()
        {
            // first calling of this method before SetNewCurrent will save null
            if (CurrentState != null)
            {
                OldStates.Push(CurrentState);
            }
            OldStates.Pop();
        }

        internal void SetNewCurrent(ProductRepositoryMemento productRepositoryMemento)
        {
            CurrentState = productRepositoryMemento;
        }
    }
}