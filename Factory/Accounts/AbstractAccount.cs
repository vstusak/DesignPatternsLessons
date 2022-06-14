namespace FactoryPattern.Accounts
{
    public abstract class AbstractAccount : IAccount
    {
        protected AbstractAccount(bool isfree)
        {
            IsFree = isfree;
        }

        public abstract string AccountType { get; }
        public bool IsFree { get; }
        public override string ToString()
        {
            return $"Account Type: {AccountType} , Is account free {IsFree}, type {GetType()}";
        }
    }
}
