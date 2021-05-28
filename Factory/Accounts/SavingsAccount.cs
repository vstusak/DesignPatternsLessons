namespace FactoryPattern.Accounts
{
    public class SavingsAccount : AbstractAccount
    {
        public SavingsAccount()
            : base(false)
        {

        }
        public SavingsAccount(bool isFree)
            : base(isFree)
        {

        }
        public override string AccountType => "savings account";
    }
}
