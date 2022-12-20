using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RegistrationApp.Pages
{
    [BindProperties]
    public class FormPostExampleModel : PageModel
    {
        [Required]
        //[RegularExpression("")]
        public int Age { get; set; }

        [StringLength(128, ErrorMessage = "Name must not be longer.")]
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var person = new PersonDbModel(Name, Age, Email);
        }
    }

    public record PersonDbModel(
        string Name,
        int Age,
        string Email);
}