using System.Xml;
using ChainOfResponsibility1.Entities;
using ChainOfResponsibility1.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChainOfResponsibility1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public bool HasBeenModelValidated { get; set; } = false;
        public List<string> Errors { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost(Person person)
        {
            var personValidator = new PersonValidator();
            Errors = personValidator.Validate(person);

            //if(IsValidName(person.Name) && IsValidSurname(person.Surname) && IsAdult(person.DateOfBirth) && IsValidNino(person.Nino, person.DateOfBirth))
            //{
            //    IsModelValid = true;
            //}
            
            HasBeenModelValidated = true;
        }
/*
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
*/
    }
}