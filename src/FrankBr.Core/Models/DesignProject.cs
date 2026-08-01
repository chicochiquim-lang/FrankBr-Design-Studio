namespace FrankBr.Core.Models;

public sealed class DesignProject
{
    public const string FileExtension = ".frankbr";

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = "Novo Projeto";
    public ProjectKind Kind { get; set; } = ProjectKind.Ets2;
    public int CanvasWidth { get; set; } = 2048;
    public int CanvasHeight { get; set; } = 2048;
    public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
}
