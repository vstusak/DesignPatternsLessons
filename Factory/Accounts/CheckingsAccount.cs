namespace FactoryPattern.Accounts
{
    public class CheckingsAccount : AbstractAccount
    {
        public CheckingsAccount()
            : base(false)
        {
                
        }
        public CheckingsAccount(bool isFree) 
            : base(isFree)
        {

        }
        public override string AccountType => "checkings account";
    }
}
