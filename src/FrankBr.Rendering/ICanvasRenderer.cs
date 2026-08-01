using FrankBr.Canvas;

namespace FrankBr.Rendering;

public interface ICanvasRenderer
{
    void Invalidate(CanvasState state);
}
