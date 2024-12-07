#nullable enable
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Y2024.Day01;

[ProblemInfo("Historian Hysteria")]
public class Solution : ISolver //, IDisplay
{
    public object PartOne(ReadOnlyMemory<char> input)
    {
        var locations = (stackalloc Location[1000]);
        input.Span.ParseToArray<Location>(ref locations);
        var l = (stackalloc int[locations.Length]);
        var r = (stackalloc int[locations.Length]);
        for (int i = 0; i < locations.Length; i++)
            (l[i], r[i]) = locations[i];
        l.Sort();
        r.Sort();
        var distances = 0;
        for (int i = 0; i < locations.Length; i++)
            distances += Math.Abs(l[i] - r[i]);
        return distances;
    }

    public object PartTwo(ReadOnlyMemory<char> input)
    {
        var locations = (stackalloc Location[1000]);
        input.Span.ParseToArray<Location>(ref locations);
        var r = (stackalloc int[locations.Length]);
        for (int i = 0; i < locations.Length; i++)
            r[i] = locations[i].Right;
        r.Sort();
        var score = 0;
        for (int i = 0; i < locations.Length; i++)
            score += System.MemoryExtensions.Count(r, locations[i].Left) * locations[i].Left;
        return score;
    }
}

readonly record struct Location(int Left, int Right) : ISpanParsable<Location>
{
    public static Location Parse(string s, IFormatProvider? provider)
    => Parse(s.AsSpan(), provider);

    public static Location Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        var values = (stackalloc Range[2]);
        s.Split(values, "   ");

        return new(int.Parse(s[values[0]]), int.Parse(s[values[1]]));
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Location result)
    => throw new NotImplementedException();

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Location result)
    {
        throw new NotImplementedException();
    }

}
