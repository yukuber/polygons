using Avalonia.Controls;
using Avalonia.Input;

namespace Polygons.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Shapes.ItemsSource = new[] { "Circle", "Triangle", "Square" };
        Shapes.SelectedIndex = 1;
        
    }

    private void InputElement_OnPointerPressed(object sender, PointerPressedEventArgs e)
    {
        CustomControl? cc = this.Find<CustomControl>("Press");
        
        var point = e.GetCurrentPoint(sender as CustomControl);
        
        if (point.Properties.IsLeftButtonPressed)
        {
            cc?.LeftClick((int)e.GetPosition(cc).X, (int)e.GetPosition(cc).Y);
        }
        if (point.Properties.IsRightButtonPressed)
        {
            cc?.RightClick((int)e.GetPosition(cc).X, (int)e.GetPosition(cc).Y);
        }
    }

    private void InputElement_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        CustomControl? cc = this.Find<CustomControl>("Press");
        cc?.Move((int)e.GetPosition(cc).X, (int)e.GetPosition(cc).Y);
    }

    private void InputElement_OnPointerReleased(object sender, PointerReleasedEventArgs e)
    {
        CustomControl? cc = this.Find<CustomControl>("Press");
        cc?.Release((int)e.GetPosition(cc).X, (int)e.GetPosition(cc).Y);
    }
    private void Shapes_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        CustomControl? cc = this.Find<CustomControl>("Press");

        int type = Shapes.SelectedIndex;
        cc?.ChangeType(type);
    }
}