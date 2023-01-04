using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public class Address
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string  Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public override string ToString()
        {
            return $"{Street}, {ZipCode} {City} {Id}";
        }
    }
}
