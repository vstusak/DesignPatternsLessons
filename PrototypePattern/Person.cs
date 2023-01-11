using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
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

        public Person()
        {
        }

        public Person(Person person)
        {
            Name = person.Name;
            Address = new Address(person.Address);
            Age = person.Age;
        }

        public Person DeepCopy()
        {
            //var person = new Person()
            //{
            //    Address = this.Address.DeepCopy(),
            //    Age = this.Age,
            //    Name = this.Name
            //};

            //return person;

            Person person = new Person(this);
            return person;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} of age {Age} ({Address.ToString()})";
        }
    }
}
