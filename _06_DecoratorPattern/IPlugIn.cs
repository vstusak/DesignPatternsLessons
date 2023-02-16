namespace _06_DecoratorPattern
{
    public interface IPlugIn
    {
        void BeforeEvent();
        void AfterEvent();
    }
}