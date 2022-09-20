namespace IteratorPattern;

public class AlphabeticalByNamePeopleIterator : IPeopleIterator
{
    private PeopleCollection _localCollection;
    private int _index;

    public AlphabeticalByNamePeopleIterator(PeopleCollection collection)
    {
        _localCollection = collection;
        _index = 0;
    }

    public bool GetNext()
    {
        if (AtEnd())
        {
            return false;
        }
        _index++;
        return true;
    }

    //@TODO - apply alphabetical sorting
    public Person Current()
    {
        return _localCollection[_index];
    }

    public bool AtEnd()
    {
        return (_index >= _localCollection.Count);
    }

    public void Reset()
    {
        _index = 0;
    }
}