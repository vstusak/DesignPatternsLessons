using System.Collections;

namespace IteratorPattern
{
    public class AlphabeticalByNamePeopleIteratorV2 : IEnumerator<Person>
    {
        private readonly List<Person> list;
        private int index;

        public AlphabeticalByNamePeopleIteratorV2(List<Person> list)
        {
            this.list = list;
            index = 0;
            Current = default;
        }
        public Person Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        { }

        public bool MoveNext()
        {
            if (index < this.list.Count)
            {
                Current = this.list
                    .OrderBy(p => p.Name)
                    .ToList()[index];
                index++;
                return true;
            }

            index = this.list.Count + 1;
            Current = default;
            return false;
        }

        public void Reset()
        {
            index = 0;
            Current = default;
        }
    }
}
