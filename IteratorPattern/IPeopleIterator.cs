namespace IteratorPattern;

public interface IPeopleIterator
{
    bool GetNext();
    Person Current();
    bool AtEnd();
    void Reset();
}