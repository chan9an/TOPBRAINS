using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int sum = 0;

        foreach (var t in tokens)
        {
            if (int.TryParse(t, out int v))
                sum += v;
        }

        Console.WriteLine(sum);
    }
}