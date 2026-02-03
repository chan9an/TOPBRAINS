using System;

namespace ExtensionMethod;
class Program
{
    static void Main()
    {
        var items = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var result = items.DistinctById();

        Console.WriteLine(string.Join(" ", result));
    }
}