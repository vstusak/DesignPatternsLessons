using DecoratorPattern.Plugins;

namespace DecoratorPattern;

public interface INotificator
{
    void RaiseEvent();

    void AddPlugin(INotificatorPlugin plugin);
    void RemovePlugin(string pluginName);
}