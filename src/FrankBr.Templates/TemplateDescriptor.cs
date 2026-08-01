using FrankBr.Core.Models;

namespace FrankBr.Templates;

public sealed record TemplateDescriptor(
    string Id,
    string DisplayName,
    ProjectKind Kind,
    int Width,
    int Height);
