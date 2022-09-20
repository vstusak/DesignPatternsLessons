namespace IteratorPattern;

public class PeopleCollection : List<Person>, IPeopleCollection
{
    public IPeopleIterator CreateIterator()
    {
        return new AlphabeticalByNamePeopleIterator(this);
    }
}