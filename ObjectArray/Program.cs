using System;

class Program
{
    static void Main()
    {
        object[] values = new object[]
        {
            10, "hello", true, null, 25, 3.5, false, 15
        };

        int sum = 0;

        foreach (var v in values)
        {
            if (v is int x)
                sum += x;
        }

        Console.WriteLine(sum);
    }
}