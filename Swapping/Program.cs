using System;

class Program
{
    static void SwapUsingRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    static void Main()
    {
        int x = 10, y = 20;

        Console.WriteLine("Before Swap:");
        Console.WriteLine($"x = {x}, y = {y}");

        SwapUsingRef(ref x, ref y);

        Console.WriteLine("After Swap (Using ref):");
        Console.WriteLine($"x = {x}, y = {y}");
    }
}
