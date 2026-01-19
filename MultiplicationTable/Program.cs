using System;

class Program
{
    static int[] MultiplicationTable(int n, int upto)
    {
        int[] result = new int[upto];

        for (int i = 1; i <= upto; i++)
        {
            result[i - 1] = n * i;
        }

        return result;
    }

    static void Main()
    {
        int n = 3;
        int upto = 5;

        int[] table = MultiplicationTable(n, upto);

        Console.WriteLine(string.Join(", ", table));
    }
}
