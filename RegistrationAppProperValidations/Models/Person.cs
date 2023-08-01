using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RegistrationAppProperValidations.Models;

public class Person
{
    [DisplayName("First name")]
    [Required]
    public string? Name { get; set; }
    [Required]
    public string Surename { get; set; }
    [Range(typeof(DateTime), "01/01/2000", "01/01/2020")]
    public DateTime DateOfBirth { get; set; }
    [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid email format")]
    public string Email { get; set; }
    public string Nino { get; set; }
}