namespace ATM;

public class BankNote
{
    public BankNote(BankNotesDenomination type, int amount)
    {
        this.Type = type;
        this.Amount = amount;
    }

    public BankNotesDenomination Type { get; init; }

    public int Amount { get; set; }
}