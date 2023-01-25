using ChainOfResponsibility1.Entities;
using ChainOfResponsibility1.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChainOfResponsibility1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost(Person person)
        {
            IsValidNino(person.Nino, person.DateOfBirth);
        }

        bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name);
        }

        bool IsValidSurname(string surname)
        {
            return !string.IsNullOrEmpty(surname);
        }

        bool IsAdult(DateTime date)
        {
            return date.AddYears(18) >= DateTime.Now;
        }

        bool IsValidNino(string nino, DateTime date)
        {
            var validator = new RWSNinoValidator();
            return validator.IsValidNino(nino, date);
        }
    }
}