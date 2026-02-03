using System;
using System.Collections.Generic;
using System.Globalization;
namespace Strings;

class Program
{
    static void Main()
    {
        List<string> shapes = new List<string>();
        string line;

        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            shapes.Add(line);

        double total = 0;

        foreach (var s in shapes)
        {
            var p = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Shape shape = null;

            if (p[0] == "C" && p.Length == 2)
                shape = new Circle(double.Parse(p[1], CultureInfo.InvariantCulture));
            else if (p[0] == "R" && p.Length == 3)
                shape = new Rectangle(
                    double.Parse(p[1], CultureInfo.InvariantCulture),
                    double.Parse(p[2], CultureInfo.InvariantCulture)
                );
            else if (p[0] == "T" && p.Length == 3)
                shape = new Triangle(
                    double.Parse(p[1], CultureInfo.InvariantCulture),
                    double.Parse(p[2], CultureInfo.InvariantCulture)
                );

            if (shape != null)
                total += shape.GetArea();
        }

        Console.WriteLine(Math.Round(total, 2, MidpointRounding.AwayFromZero));
    }
}