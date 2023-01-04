using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class Person : IPrototype<Person>
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public Address Address { get; set; }
        public int Age { get; set; }

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Id} - {Name} of age {Age} ({Address.ToString()})";
        }
    }
}
