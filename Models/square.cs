using System;
using Avalonia;
using Avalonia.Media;

namespace Polygons.Models;

public sealed class Square : Shape
{
    private Point _point1, _point2, _point3, _point4;
    private static float InnerRadius => Radius / (float)Math.Sqrt(2);
    public Square(int x, int y) : base(x, y) { }

    public override bool IsInside(int newX, int newY)
    {
        return x - InnerRadius <= newX && newX <= x + InnerRadius && y - InnerRadius <= newY && newY <= y + InnerRadius;
    }

    public override void Draw(DrawingContext context)
    {
        Brush brush = new SolidColorBrush(Color);
        Pen pen = new(brush, lineCap: PenLineCap.Square);

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