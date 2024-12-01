using System;
using System.Collections.Generic;
using polygons.Models;

namespace polygons.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        new circle() {radius = 30, color = "red"};
        new triangle(){radius = 30, color = "blue" };
        new square(){radius = 30,color = "green"};
    }
}
