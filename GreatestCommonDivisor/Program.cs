using System;

class Program
{
    static int Gcd(int a, int b)
    {
        if (b == 0) return a;
        return Gcd(b, a % b);
    }

    static void Main()
    {
        var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        Console.WriteLine(Gcd(a, b));
    }
}