namespace IteratorPattern;

public class PeopleIterator : IPeopleIterator
{
    private readonly PeopleCollection _people;
    private int _currentPosition = 0;
    public Person CurrentPerson { get; private set; }

    public PeopleIterator(PeopleCollection people)
    {
        _people = people;
        //_people = people.OrderBy(p=>p.Name).ToList();
    }

    public bool Next()
    {
        if (_currentPosition < _people.Count)
        {
            CurrentPerson = _people.OrderBy(p=>p.Name).ToList()[_currentPosition];
            _currentPosition++;
            return true;
        }
        else
        {
            return false;
        }
    }
}