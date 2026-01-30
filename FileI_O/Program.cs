using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        var lines = File.ReadAllLines("log.txt");
        var errors = lines.Where(l => l.Contains("ERROR"));
        File.WriteAllLines("error.txt", errors);
    }
}