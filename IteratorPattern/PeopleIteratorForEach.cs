using System.Collections;

namespace IteratorPattern;

public class PeopleIteratorForEach : IEnumerator<Person>
{
    private readonly PeopleCollectionForEach _people;
    private int _currentPosition = 0;
    public Person Current { get; private set; }
    object IEnumerator.Current => Current;


    public PeopleIteratorForEach(PeopleCollectionForEach people)
    {
        _people = people;
        //_people = people.OrderBy(p=>p.Name).ToList();
    }

    public bool MoveNext()
    {
        if (_currentPosition < _people.Count)
        {
            Current = _people.OrderBy(p=>p.Name).ToList()[_currentPosition];
            _currentPosition++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reset()
    {
        _currentPosition = 0;
        Current = default;
    }

    public void Dispose()
    {
        
    }
}