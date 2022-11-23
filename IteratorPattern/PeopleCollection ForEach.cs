using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    public class PeopleCollectionForEach:List<Person>
    {
        public new IEnumerator<Person> GetEnumerator()
        {
            return new PeopleIteratorForEach(this);
        }
    }
}
