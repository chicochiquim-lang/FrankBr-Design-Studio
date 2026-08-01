using System.Collections.ObjectModel;
using FrankBr.App.Models;
using FrankBr.Canvas;

namespace FrankBr.App.ViewModels;

public sealed class MainWindowViewModel
{
    public string ProductName => "FrankBr Design Studio";
    public string Slogan => "Design sem limites para simuladores e projetos gráficos.";
    public CanvasState Canvas { get; } = new();
    public ObservableCollection<CanvasImageItem> Images { get; } = [];
    public string ProjectFileName => "NovoProjeto.frankbr";
    public string ResolutionText => $"Canvas: {Canvas.Width} × {Canvas.Height}px";
    public string ZoomText => $"Zoom: {Canvas.Zoom:P0}";
}
