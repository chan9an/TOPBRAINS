using System;

class Program
{
    static double CircleArea(double radius)
    {
        double area = Math.PI * radius * radius;
        return Math.Round(area, 2, MidpointRounding.AwayFromZero);
    }

    static void Main()
    {
        double radius = double.Parse(Console.ReadLine());
        Console.WriteLine(CircleArea(radius));
    }
}