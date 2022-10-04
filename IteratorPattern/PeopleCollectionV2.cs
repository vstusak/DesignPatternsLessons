using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    public class PeopleCollectionV2 : List<Person>
    {
        public new Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
