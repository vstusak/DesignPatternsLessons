namespace ATM.Handlers
{
    internal class BanknoteHandler : Handler
    {
        private readonly BankNotesDenomination _banknoteDenomination;
        private readonly CashRegister _cashRegister;

        public BanknoteHandler(BankNotesDenomination banknoteDenomination, CashRegister cashRegister)
        {
            _banknoteDenomination = banknoteDenomination;
            _cashRegister = cashRegister;
        }

        public override void HandleRequest(int balanceToPay)
        {
            var needed = balanceToPay / (int)_banknoteDenomination;
            var registryCount = _cashRegister.GetBankNoteCount(_banknoteDenomination);
            if (registryCount >= needed)
            {
                _cashRegister.DeductBankNotes(_banknoteDenomination, needed);
                balanceToPay = balanceToPay % (int)_banknoteDenomination;
                Console.WriteLine($"We are paying out {needed} × {_banknoteDenomination} banknotes");
            }
            else
            {
                _cashRegister.DeductBankNotes(_banknoteDenomination, registryCount);
                balanceToPay -= registryCount * (int)_banknoteDenomination;
                Console.WriteLine($"We are paying out {registryCount} × {_banknoteDenomination} banknotes");
            }

            base.HandleRequest(balanceToPay);
        }
    }
}
