using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegistrationApp.Models;
using RegistrationApp.Validators;

namespace RegistrationApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public bool ValidationResult { get; set; }
        public bool HasBeenValidated { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost(Person person)
        {
            HasBeenValidated = true;
            var personValidator = new PersonValidator();
            ValidationResult = personValidator.ValidatePerson(person);
        }
    }
}