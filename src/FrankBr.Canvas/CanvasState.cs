namespace FrankBr.Canvas;

public sealed class CanvasState
{
    public int Width { get; set; } = 2048;
    public int Height { get; set; } = 2048;
    public double Zoom { get; set; } = 0.35;
    public double OffsetX { get; set; }
    public double OffsetY { get; set; }

    public double DisplayWidth => Width * Zoom;
    public double DisplayHeight => Height * Zoom;
}
