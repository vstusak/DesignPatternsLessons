namespace IteratorPattern
{
    public interface IPeopleIterator
    {
        bool Next();
        Person CurrentPerson { get; }
    }
}
