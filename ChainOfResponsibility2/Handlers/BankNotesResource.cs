namespace ChainOfResponsibility2.Handlers;

public class BankNotesResource : List<BankNote>
{
    //Method that returns sum of all values of all banknotes
    public int GetTotalBalance()
    {
        return this.Sum(v => v.Count * v.NoteValue);
    }

    public int GetLowestDenominant()
    {
        return this.Min(r=>r.NoteValue);
    }

    public int GetAvailableNotes(BankNoteDenomination noteDenom)
    {
        return this.Single(r => r.Note == noteDenom).Count;
    }
    public void UpdateAvailableNotes(BankNoteDenomination noteDenom, int usedNotes)
    {
        this.Single(r => r.Note == noteDenom).Count -= usedNotes;
    }

}