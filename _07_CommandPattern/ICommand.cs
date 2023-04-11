public interface ICommand
{
    bool CanInvoke();
    void Invoke();
    void ValidationMessage();
}