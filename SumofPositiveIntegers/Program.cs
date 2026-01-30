using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        long sum = 0;

        foreach (var x in nums)
        {
            if (x == 0) break;
            if (x < 0) continue;
            sum += x;
        }

        Console.WriteLine(sum);
    }
}