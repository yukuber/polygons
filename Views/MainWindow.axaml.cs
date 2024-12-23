using Avalonia.Controls;
using Avalonia.Input;
using System;
using polygons.Models;

namespace polygons.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void InputElement_OnPointerPressed(object sender, PointerPressedEventArgs e)
    {
        Console.WriteLine("Pointer pressed");
        CustomControl CC = this.Find<CustomControl>("InputElement");
        CC.Click((int)e.GetPosition(CC).X, (int)e.GetPosition(CC).Y);
    }

    private void InputElement_OnPointerMoved(object sender, PointerEventArgs e)
    {
        Console.WriteLine("Pointer moved");
        CustomControl CC = this.Find<CustomControl>("InputElement");
        CC.Move((int)e.GetPosition(CC).X, (int)e.GetPosition(CC).Y);
    }

    private void InputElement_OnPointerReleased(object sender, PointerReleasedEventArgs e)
    {
        CustomControl CC = this.Find<CustomControl>("InputElement");
        CC.Release((int)e.GetPosition(CC).X, (int)e.GetPosition(CC).Y);
    }
}