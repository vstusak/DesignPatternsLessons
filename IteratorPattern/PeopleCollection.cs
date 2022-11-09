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
        private int _currentPosition =0;

        public PeopleIterator(PeopleCollection people)
        {
            _people = people;
        }
        public bool AtEnd()
        {
            return _currentPosition+1 >= _people.Count;
        }

        public void Next()
        {
            if (!AtEnd())
            {
                _currentPosition++;
            }
        }

        public Person Current()
        {
            return _people[_currentPosition];
        }
    }

    public interface IPeopleCollection
    {
        IPeopleIterator CreateIterator();
    }

    public interface IPeopleIterator
    {
        bool AtEnd();
        void Next();
        Person Current();
    }
}
