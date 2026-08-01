using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace FrankBr.App.Models;

public sealed class CanvasImageItem : INotifyPropertyChanged
{
    private double x;
    private double y;
    private double width;
    private double height;
    private bool isSelected;

    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; init; } = "Imagem";
    public string SourcePath { get; init; } = string.Empty;
    public BitmapSource Source { get; init; } = null!;

    public double X { get => x; set => SetField(ref x, value); }
    public double Y { get => y; set => SetField(ref y, value); }
    public double Width { get => width; set => SetField(ref width, Math.Max(1, value)); }
    public double Height { get => height; set => SetField(ref height, Math.Max(1, value)); }
    public bool IsSelected { get => isSelected; set => SetField(ref isSelected, value); }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
