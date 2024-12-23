using System;
using Avalonia;
using Avalonia.Media;

namespace polygons.Models;

class square: shape 
{
    public square(int x, int y) : base(x, y)
    {
        
    }
    
    public override void Draw(DrawingContext dc)
    {
        Brush brush = new SolidColorBrush(Colors.Navy);
        Pen pen = new Pen(Brushes.Teal, 1, lineCap: PenLineCap.Square);

        dc.DrawRectangle(brush, pen, new Rect(x,y,radius/double.Sqrt(2),radius/double.Sqrt(2)));
        Console.WriteLine("drawing");
    }
}