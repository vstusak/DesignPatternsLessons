namespace ATM;

public class BankNoteResource : List<BankNote>
{
    public int GetCashBalance()
        => this.Sum(n => n.Amount * n.Value);

    public int GetBankNoteCount(BankNotesDenomination bankNotesDenomination)
        => this.Single(n => n.Type == bankNotesDenomination).Amount;

    public void DeductBankNotes(BankNotesDenomination bankNotesDenomination, int noOfBanknotes)
        => this.Single(n => n.Type == bankNotesDenomination).Amount -= noOfBanknotes;
}