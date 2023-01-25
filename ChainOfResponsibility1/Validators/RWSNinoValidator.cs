namespace ChainOfResponsibility1.Validators
{
    public class RWSNinoValidator : INinoValidator
    {
        public bool IsValidNino(string nino, DateTime dateOfBirth)
        {
            var dateString = dateOfBirth.ToString("yyyyMMdd");
            return dateString.Equals(nino);
        }
    }
}
