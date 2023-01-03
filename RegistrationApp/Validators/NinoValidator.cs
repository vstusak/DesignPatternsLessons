namespace RegistrationApp.Validators
{
    public class NinoValidator
    {
        public bool Validate(string nino, DateTime date)
        {
            string dateString = date.ToString("yyMMdd");
            return string.Equals(nino, dateString);
        }
    }
}
