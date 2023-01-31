using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class CashRegister
    {
        public CashRegister(int amountOf5000Banknotes, int amountOf2000Banknotes, int amountOf1000Banknotes, int amountOf500Banknotes, int amountOf200Banknotes, int amountOf100Banknotes)
        {
            AmountOf5000Banknotes = amountOf5000Banknotes;
            AmountOf2000Banknotes = amountOf2000Banknotes;
            AmountOf1000Banknotes = amountOf1000Banknotes;
            AmountOf500Banknotes = amountOf500Banknotes;
            AmountOf200Banknotes = amountOf200Banknotes;
            AmountOf100Banknotes = amountOf100Banknotes;
        }

        public int AmountOf5000Banknotes { get; set; }
        public int AmountOf2000Banknotes { get; set; }
        public int AmountOf1000Banknotes { get; set; }
        public int AmountOf500Banknotes { get; set; }
        public int AmountOf200Banknotes { get; set; }
        public int AmountOf100Banknotes { get; set; }

        public int GetCashBalance()
        {
            return (
                (AmountOf5000Banknotes * 5000) +
                (AmountOf2000Banknotes * 2000) +
                (AmountOf1000Banknotes * 1000) +
                (AmountOf500Banknotes * 500) +
                (AmountOf200Banknotes * 200) +
                (AmountOf100Banknotes * 100)
                );
        }
    }
}
