using FrankBr.Canvas;
using FrankBr.Core.Models;

namespace FrankBr.Tests;

public static class ArchitectureSmoke
{
    public static bool ValidateDefaults()
    {
        var project = new DesignProject();
        var canvas = new CanvasState();
        return project.CanvasWidth == 2048 && project.CanvasHeight == 2048 &&
               canvas.Width == 2048 && canvas.Height == 2048;
    }
}
