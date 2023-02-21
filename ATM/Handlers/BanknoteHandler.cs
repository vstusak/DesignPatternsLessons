namespace ATM.Handlers
{
    internal class BanknoteHandler : Handler
    {
        private readonly int _banknoteDenomination;
        private readonly CashRegister _cashRegister;

        public BanknoteHandler(int banknoteDenomination, CashRegister cashRegister)
        {
            _banknoteDenomination = banknoteDenomination;
            _cashRegister = cashRegister;
        }

        public override void HandleRequest(int balanceToPay)
        {
            int NoOfBanknotes = balanceToPay / _banknoteDenomination;
            if //@TODO
            Console.WriteLine($"We are paying out {NoOfBanknotes} × {_banknoteDenomination} banknotes");
            base.HandleRequest(balanceToPay % _banknoteDenomination);
        }
    }
}
