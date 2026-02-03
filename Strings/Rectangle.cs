using System;

namespace Strings;

public class Rectangle : Shape
{
    double w, h;

    public Rectangle(double w, double h)
    {
        this.w = w;
        this.h = h;
    }

    public override double GetArea()
    {
        return w * h;
    }
}