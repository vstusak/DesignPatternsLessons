namespace IteratorPattern;

public class PeopleCollection : List<Person>, IPeopleCollection
{
    public IPeopleIterator CreateIterator()
    {
        throw new NotImplementedException();
    }
}