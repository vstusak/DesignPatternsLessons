namespace DecoratorPattern.Plugins
{
    public interface INotificatorPlugin
    {
        string Name { get; }

        void BeforeRaiseEvent();
        void AfterRaiseEvent();
    }
}