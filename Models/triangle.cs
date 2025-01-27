using Avalonia.Media;
using System;
using Avalonia;

namespace Polygons.Models;

public class Triangle(int x, int y) : Shape(x, y)
{
    private Point _tpoint1, _tpoint2, _tpoint3;
    private static double Area => Radius * Radius * 0.25 * 3 * Math.Sqrt(3);


    public override void Draw(DrawingContext dc)
    {
        Brush brush = new SolidColorBrush(Color);
        Pen pen = new Pen(brush, lineCap: PenLineCap.Square);

        _tpoint1 = new Point(x, y - Radius);
        _tpoint2 = new Point(x - Radius * (float)Math.Sqrt(3) / 2, y + (float)Radius / 2);
        _tpoint3 = new Point(x + Radius * (float)Math.Sqrt(3) / 2, y + (float)Radius / 2);

        dc.DrawLine(pen, _tpoint1, _tpoint2);
        dc.DrawLine(pen, _tpoint2, _tpoint3);
        dc.DrawLine(pen, _tpoint3, _tpoint1);
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
        return Math.Abs(Area - HeronFormula(_tpoint1, _tpoint2, pointClick)
                             - HeronFormula(_tpoint1, _tpoint3, pointClick)
                             - HeronFormula(_tpoint2, _tpoint3, pointClick)) <= 0.1;
    }
}