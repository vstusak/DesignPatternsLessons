using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PeopleRegistration.Entities;

public class Person
{
    [DisplayName("First Name")]
    public string? FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public GenderType Gender { get; set; }
    [DisplayName("E-mail")]
    [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Email is not valid.")]
    public string Email { get; set; }
}

public enum GenderType
{
    Male = 0,
    Female,
    [Display(Name = "Non-binary")]
    Nonbinary
}