using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace RepositoryDesignPattern.Memento
{
    public class ProductRepositoryCareTaker
    {
        private ProductRepository _productRepository { get; }
        private readonly Stack<ProductRepositoryMemento> _undoStack = new Stack<ProductRepositoryMemento>();
        private readonly Stack<ProductRepositoryMemento> _redoStack = new Stack<ProductRepositoryMemento>();

        public ProductRepositoryCareTaker(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Push()
        {
            var memento = _productRepository.CreateMemento();
            _undoStack.Push(memento);
            _redoStack.Clear();
        }

        public void Undo()
        {
            _redoStack.Push(_productRepository.CreateMemento());
            _productRepository.SetMemento(_undoStack.Pop());
        }
        
        public void Redo()
        {
            _productRepository.SetMemento(_redoStack.Pop());
        }
    }
}
