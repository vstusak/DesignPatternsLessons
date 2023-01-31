namespace ATM.Handlers
{
    internal class Banknote100Handler : Handler
    {
        private const int banknoteDenomination = 100;

        public override void HandleRequest(int balanceToPay)
        {
            int NoOfBanknotes = balanceToPay / banknoteDenomination;
            Console.WriteLine($"We are paying out {NoOfBanknotes} × {banknoteDenomination} banknotes");
            base.HandleRequest(balanceToPay % banknoteDenomination);
        }
    }
}
