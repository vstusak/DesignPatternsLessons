namespace IteratorPattern
{
    public class PeopleCollectionV2 : List<Person>
    {
        //public new Enumerator GetEnumerator()
        //{
        //    return new Enumerator(this);
        //}

        public new IEnumerator<Person> GetEnumerator()
        {
            return new AlphabeticalByNamePeopleIteratorV2(this);
        }
    }
}
