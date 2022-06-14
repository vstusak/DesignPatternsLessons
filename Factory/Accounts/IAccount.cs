namespace FactoryPattern.Accounts
{
    public interface IAccount
    {
        string AccountType { get; }
        bool IsFree { get; }
    }
}
