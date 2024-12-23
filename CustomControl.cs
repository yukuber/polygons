using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using polygons.Models;
using System.Linq;
using System.Collections.Generic;

namespace polygons;

public class CustomControl : UserControl
{
    private int cx, cy;

    private List<shape> shapes = [ new circle(300, 400), new Triangle(300, 500) ];
    private List<shape> draggedShapes = [];

    public override void Render(DrawingContext dc)
    {
        Brush brush = new SolidColorBrush(Colors.Navy);
        Pen pen = new Pen(Brushes.Teal, 1, lineCap: PenLineCap.Square);
        
        dc.DrawEllipse(brush, pen, new Point(1500,500), 10, 10);
        Console.WriteLine("drawing");
    }

    public void Click(int newX, int newY)
    {
        foreach (var shape in shapes.Where(shape => shape.IsInside(newX, newY)))
        {
            Console.WriteLine("Click");
            cx = newX;
            cy = newY;
            shape.IsMoving = true;
            draggedShapes.Add(shape);
        }

        InvalidateVisual();
    }
    public void Move(int newX, int newY)
    {
        foreach (var shape in shapes.Where(shape => draggedShapes.Contains(shape)))
        {
            Console.WriteLine("Move");
            shape.X += newX - cx;
            shape.Y += newY - cy;
        }

        cx = newX;
        cy = newY;
        InvalidateVisual();
    }
    public void Release(int newX, int newY)
    {
        foreach (var shape in shapes.Where(shape => draggedShapes.Contains(shape)))
        {
            Console.WriteLine("Release");
            shape.X += newX - cx;
            shape.Y += newY - cy;
            shape.IsMoving = false;
            draggedShapes.Remove(shape);
        }

        cx = newX;
        cy = newY;
        InvalidateVisual();
    }
    
}