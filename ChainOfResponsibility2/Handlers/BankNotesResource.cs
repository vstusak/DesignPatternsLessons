namespace ChainOfResponsibility2.Handlers;

public class BankNotesResource : List<BankNote>, IBankNotesResource
{
    public BankNotesResource()
    {
        Add(new BankNote(BankNoteDenomination.OneHundred, 0));
        Add(new BankNote(BankNoteDenomination.TwoHundred, 5));
        Add(new BankNote(BankNoteDenomination.FourHundred, 2));
        Add(new BankNote(BankNoteDenomination.FiveHundred, 2));
        Add(new BankNote(BankNoteDenomination.OneThousand, 2));
        Add(new BankNote(BankNoteDenomination.TwoThousand, 0));
        Add(new BankNote(BankNoteDenomination.FiveThousand, 1));
    }

    //Method that returns sum of all values of all banknotes
    public int GetTotalBalance()
    {
        return this.Sum(v => v.Count * v.NoteValue);
    }

    public int GetLowestDenominant()
    {
        return this.Min(r => r.NoteValue);
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