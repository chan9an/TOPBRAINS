using System;

class Program
{
    static void Main()
    {
        int totalSeconds = int.Parse(Console.ReadLine());
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        Console.WriteLine($"{minutes}:{seconds:D2}");
    }
}