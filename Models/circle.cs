using Avalonia.Media;
using System;
using Avalonia;

namespace polygons.Models;

public sealed class Circle : Shape
{
    public Circle(int x, int y) : base(x, y) { }

    public override void Draw(DrawingContext dc)
    {
        Brush brush = new SolidColorBrush(Colors.DarkSlateBlue);
        //Brush brush2 = new SolidColorBrush(color);
        Pen pen = new Pen(Brushes.Teal, lineCap: PenLineCap.Square);

        dc.DrawEllipse(brush, pen, new Point(x, y), Radius, Radius);
        Console.WriteLine("drawing");
    }

    public override bool IsInside(int nx, int ny)
    {
        return (x - nx) * (x - nx) + (y - ny) * (y - ny) <= Radius * Radius;
    }
}
    