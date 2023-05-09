public interface ICommand
{
    bool CanInvoke();
    void Invoke();
    void Undo();
    void ValidationMessage();
}