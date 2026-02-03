using System;

namespace Strings;
public class Triangle : Shape
{
    double b, h;

    public Triangle(double b, double h)
    {
        this.b = b;
        this.h = h;
    }

    public override double GetArea()
    {
        return 0.5 * b * h;
    }
}