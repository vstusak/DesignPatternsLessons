namespace ChainOfResponsibility1.Validators
{
    public interface INinoValidator
    {
        bool IsValidNino(string nino, DateTime dateOfBirth);
    }
}
