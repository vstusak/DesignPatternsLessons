namespace ChainOfResponsibility2.Handlers
{
    public interface IBankNotesResource : IEnumerable<BankNote>
    {
        int GetAvailableNotes(BankNoteDenomination noteDenom);
        int GetLowestDenominant();
        int GetTotalBalance();
        void UpdateAvailableNotes(BankNoteDenomination noteDenom, int usedNotes);
    }
}