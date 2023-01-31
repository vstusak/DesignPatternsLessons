namespace ATM.Handlers
{
    internal class Banknote1000Handler : Handler
    {
        private const int banknoteDenomination = 1000;

        public override void HandleRequest(int balanceToPay)
        {
            int NoOfBanknotes = balanceToPay / banknoteDenomination;
            Console.WriteLine($"We are paying out {NoOfBanknotes} × {banknoteDenomination} banknotes");
            base.HandleRequest(balanceToPay % banknoteDenomination);
        }
    }
}
