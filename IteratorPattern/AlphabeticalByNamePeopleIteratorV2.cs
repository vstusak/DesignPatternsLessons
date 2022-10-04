using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    public class AlphabeticalByNamePeopleIteratorV2 : IEnumerator<Person>
    {
        private List<Person> list;
        private int index;
        private Person current;

        public AlphabeticalByNamePeopleIteratorV2(List<Person> list)
        {
            this.list = list;
            index = 0;            
            current = default(Person);
        }
        public Person Current => current;

        object IEnumerator.Current => current;

        public void Dispose()
        {        }

        public bool MoveNext()
        {
            if (index < this.list.Count)
            {
                current = this.list[index];
                index++;
                return true;
            }

            index = this.list.Count + 1;
            current = default(Person);
            return false;
        }

        public void Reset()
        {
            index = 0;
            current = default(Person);
        }
    }
}
