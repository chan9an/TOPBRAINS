using System;
using System.Collections.Generic;

namespace ExtensionMethod;

public static class StringExtensions
{
    public static string[] DistinctById(this string[] items)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (var item in items)
        {
            var parts = item.Split(':');
            if (parts.Length != 2) continue;

            if (seen.Add(parts[0]))
                result.Add(parts[1]);
        }

        return result.ToArray();
    }
}