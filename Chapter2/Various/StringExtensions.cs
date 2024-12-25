using System.Text;

namespace Various;

public static class StringExtensions
{
    public static string SimpleReverse(this string s)
    {
        return new string(s.Reverse().ToArray());
    }
    
    public static string RuneReverse(this string input)
    {
        var runes = input.EnumerateRunes().ToArray();
        Array.Reverse(runes);
        var reversed = new StringBuilder();
        foreach (var rune in runes)
            reversed.Append(rune);
        return reversed.ToString();
    }
}
