namespace ChainOfResponsibility2.Handlers;

public static class Constants
{
    public static int LowestBankNote = Enum.GetValues(typeof(BankNotes)).Cast<int>().Min();
}