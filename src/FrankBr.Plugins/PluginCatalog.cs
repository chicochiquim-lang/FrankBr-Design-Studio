using FrankBr.Core.Contracts;

namespace FrankBr.Plugins;

public sealed class PluginCatalog
{
    private readonly List<IPlugin> _plugins = [];

    public IReadOnlyList<IPlugin> Plugins => _plugins;

    public void Register(IPlugin plugin)
    {
        ArgumentNullException.ThrowIfNull(plugin);
        if (_plugins.Any(item => string.Equals(item.Id, plugin.Id, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"O plugin '{plugin.Id}' já está registrado.");
        }

        plugin.Initialize();
        _plugins.Add(plugin);
    }
}
