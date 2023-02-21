using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class CashRegister
    {
        private readonly Dictionary<BankNotesDenomination, int> _register;

        public CashRegister(int amountOf5000Banknotes, int amountOf2000Banknotes, int amountOf1000Banknotes, int amountOf500Banknotes, int amountOf200Banknotes, int amountOf100Banknotes)
        {
            _register = new Dictionary<BankNotesDenomination, int>()
            {
                { BankNotesDenomination.BankNote5000, amountOf5000Banknotes },
                { BankNotesDenomination.BankNote2000, amountOf2000Banknotes },
                { BankNotesDenomination.BankNote1000, amountOf1000Banknotes },
                { BankNotesDenomination.BankNote500, amountOf500Banknotes },
                { BankNotesDenomination.BankNote200, amountOf200Banknotes },
                { BankNotesDenomination.BankNote100, amountOf100Banknotes }
            };
        }
        public int GetCashBalance()
        {
            return
                _register[BankNotesDenomination.BankNote5000] * (int)BankNotesDenomination.BankNote5000 +
                _register[BankNotesDenomination.BankNote2000] * (int)BankNotesDenomination.BankNote2000 +
                _register[BankNotesDenomination.BankNote1000] * (int)BankNotesDenomination.BankNote1000 +
                _register[BankNotesDenomination.BankNote500] * (int)BankNotesDenomination.BankNote500 +
                _register[BankNotesDenomination.BankNote200] * (int)BankNotesDenomination.BankNote200 +
                _register[BankNotesDenomination.BankNote100] * (int)BankNotesDenomination.BankNote100;
        }
    }
}
