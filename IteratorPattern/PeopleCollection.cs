using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    public class PeopleCollection:List<Person>, IPeopleCollection
    {
        public IPeopleIterator CreateIterator()
        {
            return new PeopleIterator(this);
        }
    }

    public class PeopleIterator : IPeopleIterator
    {
        private readonly PeopleCollection _people;
        private int _currentPosition = 0;
        public Person CurrentPerson { get; private set; }

        public PeopleIterator(PeopleCollection people)
        {
            _people = people;
        }

        public bool Next()
        {
            if (_currentPosition < _people.Count)
            {
                CurrentPerson = _people[_currentPosition];
                _currentPosition++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public interface IPeopleCollection
    {
        IPeopleIterator CreateIterator();
    }

    public interface IPeopleIterator
    {
        bool Next();
        Person CurrentPerson { get; }
    }
}
