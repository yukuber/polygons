using System;
using System.Linq;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Polygons.Models;


namespace Polygons;

public class CustomControl : UserControl
{
    private int _cx, _cy;
    private int _shapeType;

    private List<Shape> _shapes = [];
    
    public override void Render(DrawingContext dc)
    {
        foreach (var shape in _shapes)
        {
            shape.Draw(dc);
        }
        Console.WriteLine("Drawing shapes");
        if (_shapes.Count >= 3)
        {
            DrawShell(dc);
        }
    }

    public void LeftClick(int newX, int newY)
    {
        bool inside = false;
        foreach (var shape in _shapes.Where(shape => shape.IsInside(newX, newY)))
        {
            
            Console.WriteLine("Click");
            _cx = newX;
            _cy = newY;
            shape.IsMoving = true;
            inside = true;
        }

        if (!inside)
        {
            switch (_shapeType)
            {
                case 0:
                    _shapes.Add(new Circle(newX, newY));
                    break;
                case 1:
                    _shapes.Add(new Triangle(newX, newY));
                    break;
                case 2:
                    _shapes.Add(new Square(newX, newY));
                    break;
            }

        }
        if (_shapes.Count >= 3)
        {
            UpdatePointsInShell();
            var drag = false;
            if (!_shapes.Last().IsInShell)
            {
                drag = true;
                _shapes.Remove(_shapes.Last());
                foreach (var shape in _shapes)
                {
                    shape.IsMoving = true;
                }

                _cx = newX;
                _cy = newY;
            }

            if (!drag)
            {
                RemoveShapesInsideShell();
            }
        }

        InvalidateVisual();
    }
    
    
    public void Move(int newX, int newY)
    {
        foreach (var shape in _shapes.Where(shape => shape.IsMoving))
        {
            Console.WriteLine("Move");
            shape.X += newX - _cx;
            shape.Y += newY - _cy;
        }

        _cx = newX;
        _cy = newY;
        InvalidateVisual();
    }
    public void Release(int newX, int newY)
    {
        foreach (var shape in _shapes.Where(shape => shape.IsMoving))
        {
            Console.WriteLine("Release");
            shape.X += newX - _cx;
            shape.Y += newY - _cy;
            shape.IsMoving = false;
        }

        _cx = newX;
        _cy = newY;
        RemoveShapesInsideShell();
        InvalidateVisual();
    }
    public void ChangeType(int type)
    {                               
        _shapeType = type;       
    }                               
    private void RemoveShapesInsideShell()
    {
        foreach (var shape in _shapes.ToList().Where(shape => !shape.IsInShell))
        {
            _shapes.Remove(shape);
        }

        InvalidateVisual();
    }
    public void RightClick(int newX, int newY)
    {
        foreach (var shape in _shapes.Where(shape => shape.IsInside(newX, newY)).Reverse())
        {
            _cx = newX;
            _cy = newY;
            _shapes.Remove(shape);
            break;
        }

        InvalidateVisual();
    }


     private void DrawShell(DrawingContext dc)
    {
        foreach (var shape in _shapes)
        {
            shape.IsInShell = false;
        }

        int i = 0;
        foreach (var s1 in _shapes)
        {
            if (i == _shapes.Count - 1)
            {
                break;
            }

            int j = 0;
            foreach (var s2 in _shapes)
            {
                if (j <= i)
                {
                    j++;
                    continue;
                }

                int l = 0;
                bool upper = false, lower = false;
                double k = (double)(s2.Y - s1.Y) / (s2.X - s1.X);
                double b = s2.Y - k * s2.X;
                foreach (var s3 in _shapes)
                {
                    if (l != i && l != j)
                    {
                        if (s1.X != s2.X)
                        {
                            if (s3.X * k + b > s3.Y)
                            {
                                lower = true;
                            }
                            else if (s3.X * k + b < s3.Y)
                            {
                                upper = true;
                            }
                        }
                        else
                        {
                            if (s2.X > s3.X)
                            {
                                lower = true;
                            }
                            else if (s2.X < s3.X)
                            {
                                upper = true;
                            }
                        }
                    }

                    l++;
                }

                if (lower==upper != true)
                {
                    Brush brush = new SolidColorBrush(Colors.Magenta);
                    Pen pen = new(brush, lineCap: PenLineCap.Square);
                    var point1 = new Point(s1.X, s1.Y);
                    var point2 = new Point(s2.X, s2.Y);
                    s1.IsInShell = true;
                    s2.IsInShell = true;
                    dc.DrawLine(pen, point1, point2);
                }

                j++;
            }

            i++;
        }
    }

    private void UpdatePointsInShell()
    {
        foreach (var shape in _shapes)
        {
            shape.IsInShell = false;
        }

        int i = 0;
        foreach (var s1 in _shapes)
        {
            if (i == _shapes.Count - 1)
            {
                break;
            }

            int j = 0;
            foreach (var s2 in _shapes)
            {
                if (j <= i)
                {
                    j++;
                    continue;
                }

                int l = 0;
                bool upper = false, lower = false;
                double k = (double)(s2.Y - s1.Y) / (s2.X - s1.X);
                double b = s1.Y - k * s2.X;
                foreach (var s3 in _shapes)
                {
                    if (l != i && l != j)
                    {
                        if (s1.X != s2.X)
                        {
                            if (s3.X * k + b > s3.Y)
                            {
                                lower = true;
                            }
                            else if (s3.X * k + b < s3.Y)
                            {
                                upper = true;
                            }
                        }
                        else
                        {
                            if (s2.X > s3.X)
                            {
                                lower = true;
                            }
                            else if (s2.X < s3.X)
                            {
                                upper = true;
                            }
                        }
                    }

                    l++;
                }

                if (upper != lower || (upper == false && lower == false))
                {
                    s1.IsInShell = true;
                    s2.IsInShell = true;
                }

                j++;
            }

            i++;
        }
    }
}