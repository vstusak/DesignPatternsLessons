using System.Dynamic;

namespace ChainOfResponsibility2.Handlers;

public class BankNote 
{
    public BankNoteDenomination Note { get; }
    
    public int NoteValue => (int)Note; 

    public int Count { get; set; }

    public BankNote(BankNoteDenomination note, int count)
    {
        Note = note;
        Count = count;
    }
}