using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProductStore.Contracts.Model
{
    [PrimaryKey("Email","Name", "Age")]
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        [MaxLength(69)]
        public string Email { get; set; }
    }
}
