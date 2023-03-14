namespace ATM;

public class CashRegister
{
    private readonly IList<BankNote> notes;

    public CashRegister(
        int amountOf5000Banknotes,int amountOf2000Banknotes,int amountOf1000Banknotes,int amountOf500Banknotes,int amountOf200Banknotes,int amountOf100Banknotes)
    {
        notes = new List<BankNote>
        {
            new(BankNotesDenomination.BankNote5000, amountOf5000Banknotes),
            new(BankNotesDenomination.BankNote2000, amountOf2000Banknotes),
            new(BankNotesDenomination.BankNote1000, amountOf1000Banknotes),
            new(BankNotesDenomination.BankNote500, amountOf500Banknotes),
            new(BankNotesDenomination.BankNote200, amountOf200Banknotes),
            new(BankNotesDenomination.BankNote100, amountOf100Banknotes)
        };
    }
    #region oldImplementation
    //_register = new Dictionary<BankNotesDenomination, int>
    //{
    //    { BankNotesDenomination.BankNote5000, amountOf5000Banknotes },
    //    { BankNotesDenomination.BankNote2000, amountOf2000Banknotes },
    //    { BankNotesDenomination.BankNote1000, amountOf1000Banknotes },
    //    { BankNotesDenomination.BankNote500, amountOf500Banknotes },
    //    { BankNotesDenomination.BankNote200, amountOf200Banknotes },
    //    { BankNotesDenomination.BankNote100, amountOf100Banknotes }
    //};

    //private readonly Dictionary<BankNotesDenomination, int> _register;
    //public int GetCashBalance()
    //    => _register[BankNotesDenomination.BankNote5000] * (int)BankNotesDenomination.BankNote5000
    //        + _register[BankNotesDenomination.BankNote2000] * (int)BankNotesDenomination.BankNote2000
    //        + _register[BankNotesDenomination.BankNote1000] * (int)BankNotesDenomination.BankNote1000
    //        + _register[BankNotesDenomination.BankNote500] * (int)BankNotesDenomination.BankNote500
    //        + _register[BankNotesDenomination.BankNote200] * (int)BankNotesDenomination.BankNote200
    //        + _register[BankNotesDenomination.BankNote100] * (int)BankNotesDenomination.BankNote100;

    //public void DeductBankNotes(BankNotesDenomination bankNotesDenomination, int noOfBanknotes)
    //    => _register[bankNotesDenomination] -= noOfBanknotes;

    //public int GetBankNoteCount(BankNotesDenomination bankNotesDenomination)
    //    => _register[bankNotesDenomination];
    #endregion
    public int GetCashBalance()
        => notes.Sum(n => n.Amount * n.Value);

    public int GetBankNoteCount(BankNotesDenomination bankNotesDenomination)
        => notes.Single(n => n.Type == bankNotesDenomination).Amount;

    public void DeductBankNotes(BankNotesDenomination bankNotesDenomination, int noOfBanknotes)
        => notes.Single(n => n.Type == bankNotesDenomination).Amount -= noOfBanknotes;


}
