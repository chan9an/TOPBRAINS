using System;

class Program
{
    public static string CleanseAndInvert(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return "";

        foreach (char c in input)
        {
            if (!char.IsLetter(c))
                return "";
        }

        input = input.ToLower();

        string filtered = "";
        foreach (char c in input)
        {
            if ((int)c % 2 != 0)
                filtered += c;
        }

        char[] arr = filtered.ToCharArray();
        Array.Reverse(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
                arr[i] = char.ToUpper(arr[i]);
        }

        return new string(arr);
    }

    static void Main()
    {
        string input = Console.ReadLine();
        string result = CleanseAndInvert(input);

        if (result.Length == 0)
            Console.WriteLine("invalid");
        else
            Console.WriteLine("Generated String is: " + result);
    }
}