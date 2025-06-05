using DecoratorPattern.Plugins;

namespace DecoratorPattern;

public class Notificator : INotificator
{
    private readonly List<INotificatorPlugin> plugins = [];

    public Notificator()
    {
    }

    public void RaiseEvent()
    {
        plugins.ForEach(plugin => plugin.BeforeRaiseEvent());
        Console.WriteLine("Event raised");
        plugins.ForEach(plugin => plugin.AfterRaiseEvent());
    }

    public void AddPlugin(INotificatorPlugin plugin)
    {
        plugins.Add(plugin);
    }

    public void RemovePlugin(string pluginName)
    {
        var plugin = plugins.FirstOrDefault(p => p.Name.Equals(pluginName, StringComparison.OrdinalIgnoreCase));

        if (plugin != null)
        {
            plugins.Remove(plugin);
        }
    }
}