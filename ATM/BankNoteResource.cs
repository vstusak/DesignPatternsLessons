namespace ATM;
using static ATM.BankNotesDenomination;

public class BankNoteResource : List<BankNote>, IBankNoteResource
{
    public BankNoteResource()
    {
        this.Add(new(BankNote5000, 10));
        this.Add(new(BankNote2000, 10));
        this.Add(new(BankNote1000, 10));
        this.Add(new(BankNote500, 20));
        this.Add(new(BankNote200, 10));
        this.Add(new(BankNote100, 50));
    }

    public int GetCashBalance()
        => this.Sum(n => n.Amount * n.Value);

    public int GetBankNoteCount(BankNotesDenomination bankNotesDenomination)
        => this.Single(n => n.Type == bankNotesDenomination).Amount;

    public void DeductBankNotes(BankNotesDenomination bankNotesDenomination, int noOfBanknotes)
        => this.Single(n => n.Type == bankNotesDenomination).Amount -= noOfBanknotes;
}