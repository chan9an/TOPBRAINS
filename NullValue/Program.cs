using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var parts = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
        double sum = 0;
        int count = 0;

        foreach (var p in parts)
        {
            if (p.Equals("null", StringComparison.OrdinalIgnoreCase)) continue;
            if (double.TryParse(p, out double v))
            {
                sum += v;
                count++;
            }
        }

        if (count == 0)
            Console.WriteLine("null");
        else
            Console.WriteLine(Math.Round(sum / count, 2, MidpointRounding.AwayFromZero));
    }
}