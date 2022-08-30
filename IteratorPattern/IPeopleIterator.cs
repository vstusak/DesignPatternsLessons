namespace IteratorPattern;

public interface IPeopleIterator
{
    Person GetNext();
    Person Current();
    bool AtEnd();
    void Reset();
}