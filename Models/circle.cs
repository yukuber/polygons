using Avalonia.Media;
using System;
using Avalonia;

namespace polygons.Models;

class circle : shape
{
    public circle(int x, int y) : base(x, y)
    {
    }

    public override void Draw(DrawingContext dc)
    {
        Brush brush = new SolidColorBrush(Colors.Navy);
        Pen pen = new Pen(Brushes.Teal, 1, lineCap: PenLineCap.Square);

        dc.DrawEllipse(brush, pen, new Point(x, y), radius, radius);
        Console.WriteLine("drawing");
    }

    public override bool IsInside(int nx, int ny)
    {
        return (x - nx) * (x - nx) + (y - ny) * (y - ny) <= radius * radius;
    }
}
    