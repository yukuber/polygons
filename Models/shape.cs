using System;
using System.Xml.Schema;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace polygons.Models;

public abstract class shape //не sealed тк через него можно объявлять экземпляры, не нельзя наследовать
//тк shape - статический конструктор, у него нет параметров
{
    protected int x;
    protected int y;
    protected static int radius;
    protected Color color;
    public bool IsMoving {get; set;}
    public abstract bool IsInside(int nx, int ny);
    static shape()
    {
        radius = 30;
    }

    protected shape(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }

    public abstract void Draw(DrawingContext dc);
    
    public bool IsInShell { get; set; } = true;

}

