using FrankBr.Core.Models;

namespace FrankBr.Documents;

public sealed class FrankBrDocument
{
    public DesignProject Project { get; init; } = new();
    public string? FilePath { get; set; }
    public bool IsDirty { get; set; }
}
