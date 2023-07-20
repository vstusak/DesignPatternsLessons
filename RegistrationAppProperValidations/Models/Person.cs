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
    public DateTime DateOfBirth { get; set; }
    public string Nino { get; set; }
}