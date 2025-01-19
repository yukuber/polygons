using System;
using Avalonia;
using Avalonia.Media;

namespace polygons.Models;

public sealed class Square : shape
{
    private Point _point1, _point2, _point3, _point4;
    private static float InnerRadius => radius / (float)Math.Sqrt(2);
    public Square(int x, int y) : base(x, y) { }

    public override bool IsInside(int newX, int newY)
    {
        return x - InnerRadius <= newX && newX <= x + InnerRadius && y - InnerRadius <= newY && newY <= y + InnerRadius;
    }

    public override void Draw(DrawingContext context)
    {
        Brush Brush = new SolidColorBrush(Colors.Aquamarine);
        Pen pen = new(Brush, 2, lineCap: PenLineCap.Square);

        _point1 = new Point(x - InnerRadius, y + InnerRadius);
        _point2 = new Point(x + InnerRadius, y + InnerRadius);
        _point3 = new Point(x + InnerRadius, y - InnerRadius);
        _point4 = new Point(x - InnerRadius, y - InnerRadius);
        context.DrawLine(pen, _point1, _point2);
        context.DrawLine(pen, _point2, _point3);
        context.DrawLine(pen, _point3, _point4);
        context.DrawLine(pen, _point4, _point1);
    }
}