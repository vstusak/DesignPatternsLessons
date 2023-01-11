using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class Address:IPrototype<Address>
    {
        public Address()
        {
        }


        public Address(Address address)
        {
           Street = address.Street;
           City = address.City;
           ZipCode = address.ZipCode;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public string  Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public override string ToString()
        {
            return $"{Street}, {ZipCode} {City} {Id}";
        }

        public Address ShallowCopy()
        {
            return (Address)this.MemberwiseClone();
        }

        public Address DeepCopy()
        {
            var address = new Address
            {
                City = this.City,
                Street = this.Street,
                ZipCode = this.ZipCode
            };
            return address;
        }
    }
}
