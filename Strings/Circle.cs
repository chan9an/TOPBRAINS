using System;

namespace Strings;

public class Circle : Shape
{
    double r;

    public Circle(double r)
    {
        this.r = r;
    }

    public override double GetArea()
    {
        return Math.PI * r * r;
    }
}
