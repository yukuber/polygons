using System;
using System.Xml.Schema;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace polygons.Models;

public class shape //не sealed тк через него можно объявлять экземпляры, не нельзя наследовать
//тк shape - статический конструктор, у него нет параметров
{
    protected int x { get; set; }
    protected int y { get; set; }
    protected static int radius { get; set; }
    // protected int color { get; set; }
    static shape()
    {
        radius = 30;
    }

    public shape(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public virtual void Draw(DrawingContext dc) {}

}

