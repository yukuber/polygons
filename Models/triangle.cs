using Avalonia.Media;
using System;
using Avalonia;
using Avalonia.Controls.Shapes;

namespace polygons.Models;

public class Triangle : shape
{
    private Point Tpoint1, Tpoint2, Tpoint3;
    private static double Area => radius * radius * 0.25 * 3 * Math.Sqrt(3);


    public Triangle(int x, int y) : base(x, y)
    {
    }


    public override void Draw(DrawingContext dc)
    {
        Brush brush = new SolidColorBrush(Colors.Navy);
        Pen pen = new Pen(Brushes.Teal, 1, lineCap: PenLineCap.Square);

        Tpoint1 = new Point(x, y - radius);
        Tpoint2 = new Point(x - radius * (float)Math.Sqrt(3) / 2, y + (float)radius / 2);
        Tpoint3 = new Point(x + radius * (float)Math.Sqrt(3) / 2, y + (float)radius / 2);

        dc.DrawLine(pen, Tpoint1, Tpoint2);
        dc.DrawLine(pen, Tpoint2, Tpoint3);
        dc.DrawLine(pen, Tpoint3, Tpoint1);
        Console.WriteLine("drawing");
    }

    private static double HeronFormula(Point p1, Point p2, Point p3)
    {
        var a = Point.Distance(p1, p2);
        var b = Point.Distance(p1, p3);
        var c = Point.Distance(p2, p3);
        var p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public override bool IsInside(int nx, int ny)
    {
        var pointClick = new Point(nx, ny);
        return Math.Abs(Area - HeronFormula(Tpoint1, Tpoint2, pointClick)
                             - HeronFormula(Tpoint1, Tpoint3, pointClick)
                             - HeronFormula(Tpoint2, Tpoint3, pointClick)) <= 0.1;
    }
}