using System;
using System.Xml.Schema;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace polygons.Models;

public abstract class shape //не sealed тк через него можно объявлять экземпляры, не нельзя наследовать
//тк shape - статический конструктор, у него нет параметров
{
    protected int x { get; set; }
    protected int y { get; set; }
    protected static int radius { get; set; }
    // protected Color color { get; set; }
    public bool IsMoving {get; set;}
    public abstract bool IsInside(int nx, int ny);
    static shape()
    {
        radius = 30;
    }

    public shape(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    public virtual void Draw(DrawingContext dc) {}

}

