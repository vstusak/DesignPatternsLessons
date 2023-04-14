namespace ATM
{
    public interface IBankNoteResource
    {
        void DeductBankNotes(BankNotesDenomination bankNotesDenomination, int noOfBanknotes);
        int GetBankNoteCount(BankNotesDenomination bankNotesDenomination);
        int GetCashBalance();
    }
}