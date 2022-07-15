using RepositoryPattern.Memento;

namespace CommandPattern.Memento
{
    public class RepositoryCareTaker
    {
        private Stack<ProductRepositoryMemento> OldStates { get; set; } = new();
        private ProductRepositoryMemento CurrentState { get; set; }

        public int Count => OldStates.Count;

        public void PushCurrentToHistory()
        {
            // first calling of this method before SetNewCurrent will save null
            if (CurrentState != null)
            {
                OldStates.Push(CurrentState);
            }
        }

        public void SetNewCurrent(ProductRepositoryMemento productRepositoryMemento)
        {
            CurrentState = productRepositoryMemento;
        }

        public ProductRepositoryMemento PopState()
        {
            return OldStates.Pop();
        }
    }
}