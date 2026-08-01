using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FrankBr.App.Models;
using FrankBr.App.ViewModels;
using Microsoft.Win32;

namespace FrankBr.App;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel viewModel = new();
    private CanvasImageItem? selectedItem;
    private Point dragStart;
    private double itemStartX;
    private double itemStartY;
    private bool isDragging;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = viewModel;
        DesignCanvas.MouseMove += DesignCanvas_MouseMove;
    }

    private void ImportImage_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Imagens (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
            Multiselect = true
        };

        if (dialog.ShowDialog() != true) return;

        foreach (var path in dialog.FileNames)
        {
            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.UriSource = new Uri(path, UriKind.Absolute);
                bitmap.EndInit();
                bitmap.Freeze();

                const double maxDisplaySize = 420;
                var scale = Math.Min(1.0, maxDisplaySize / Math.Max(bitmap.PixelWidth, bitmap.PixelHeight));
                var width = Math.Max(30, bitmap.PixelWidth * scale * viewModel.Canvas.Zoom);
                var height = Math.Max(30, bitmap.PixelHeight * scale * viewModel.Canvas.Zoom);

                var item = new CanvasImageItem
                {
                    Name = Path.GetFileNameWithoutExtension(path),
                    SourcePath = path,
                    Source = bitmap,
                    Width = width,
                    Height = height,
                    X = Math.Max(0, (DesignCanvas.Width - width) / 2 + viewModel.Images.Count * 16),
                    Y = Math.Max(0, (DesignCanvas.Height - height) / 2 + viewModel.Images.Count * 16)
                };

                viewModel.Images.Add(item);
                SelectItem(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível importar a imagem.\n{ex.Message}", "FrankBr Design Studio", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    private void ImageItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (sender is not Border border || border.DataContext is not CanvasImageItem item) return;

        SelectItem(item);
        dragStart = e.GetPosition(DesignCanvas);
        itemStartX = item.X;
        itemStartY = item.Y;
        isDragging = true;
        border.CaptureMouse();
        e.Handled = true;
    }

    private void ImageItem_MouseMove(object sender, MouseEventArgs e)
    {
        if (!isDragging || selectedItem is null || e.LeftButton != MouseButtonState.Pressed) return;

        var current = e.GetPosition(DesignCanvas);
        selectedItem.X = Math.Clamp(itemStartX + current.X - dragStart.X, 0, Math.Max(0, DesignCanvas.Width - selectedItem.Width));
        selectedItem.Y = Math.Clamp(itemStartY + current.Y - dragStart.Y, 0, Math.Max(0, DesignCanvas.Height - selectedItem.Height));
        UpdateSelectionText();
    }

    private void ImageItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        isDragging = false;
        if (sender is Border border) border.ReleaseMouseCapture();
        e.Handled = true;
    }

    private void DesignCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.OriginalSource == DesignCanvas) SelectItem(null);
    }

    private void DesignCanvas_MouseMove(object sender, MouseEventArgs e)
    {
        var point = e.GetPosition(DesignCanvas);
        var scale = 1.0 / viewModel.Canvas.Zoom;
        MouseXText.Text = $"X: {Math.Clamp(point.X * scale, 0, 2048):0}";
        MouseYText.Text = $"Y: {Math.Clamp(point.Y * scale, 0, 2048):0}";
    }

    private void Layers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ListBox listBox && listBox.SelectedItem is CanvasImageItem item)
            SelectItem(item);
    }

    private void DeleteSelected_Click(object sender, RoutedEventArgs e) => DeleteSelected();

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Delete)
        {
            DeleteSelected();
            e.Handled = true;
        }
        else if (e.Key == Key.I && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
        {
            ImportImage_Click(sender, e);
            e.Handled = true;
        }
    }

    private void DeleteSelected()
    {
        if (selectedItem is null) return;
        viewModel.Images.Remove(selectedItem);
        SelectItem(null);
    }

    private void SelectItem(CanvasImageItem? item)
    {
        foreach (var image in viewModel.Images)
            image.IsSelected = ReferenceEquals(image, item);

        selectedItem = item;
        UpdateSelectionText();
    }

    private void UpdateSelectionText()
    {
        if (selectedItem is null)
        {
            SelectionNameText.Text = "Nenhum objeto selecionado";
            SelectionPositionText.Text = "Canvas: 2048 × 2048 px";
            return;
        }

        SelectionNameText.Text = selectedItem.Name;
        SelectionPositionText.Text = $"X: {selectedItem.X / viewModel.Canvas.Zoom:0}  Y: {selectedItem.Y / viewModel.Canvas.Zoom:0}\nTamanho: {selectedItem.Width / viewModel.Canvas.Zoom:0} × {selectedItem.Height / viewModel.Canvas.Zoom:0} px";
    }

    private void Exit_Click(object sender, RoutedEventArgs e) => Close();
}
