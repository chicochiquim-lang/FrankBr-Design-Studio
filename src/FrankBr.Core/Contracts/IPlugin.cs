namespace FrankBr.Core.Contracts;

public interface IPlugin
{
    string Id { get; }
    string Name { get; }
    Version Version { get; }
    void Initialize();
}
