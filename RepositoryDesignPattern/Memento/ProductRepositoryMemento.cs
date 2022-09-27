using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.Memento
{
    public class ProductRepositoryMemento
    {
        private string State { get; set; }

        public ProductRepositoryMemento(string state)
        {
            SetState(state);
        }

        public void SetState(string state)
        {
            //Possible additional processing here (like compress data etc.)
            State = state;
        }

        public string GetState()
        {
            //Possible additional processing here (like decompress data etc.)
            return State;
        }

    }
}
