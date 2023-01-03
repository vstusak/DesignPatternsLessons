using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    public interface IWatcher
    {
        void EventRaised(TextBox textBox);
    }
}