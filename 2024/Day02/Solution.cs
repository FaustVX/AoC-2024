#nullable enable
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Y2024.Day02;

using static System.MemoryExtensions;

[ProblemInfo("Red-Nosed Reports")]
public class Solution : ISolver //, IDisplay
{
    public object PartOne(ReadOnlyMemory<char> input)
    {
        var reports = Extensions.ParseToArray(input.Span, stackalloc Buffer[input.Span.Count('\n') + 1]);
        var count = 0;
        foreach (var item in reports)
            if (item.IsValid())
                count++;
        return count;
    }

    public object PartTwo(ReadOnlyMemory<char> input)
    {
        return 0;
    }
}

[System.Runtime.CompilerServices.InlineArray(9)]
file struct Buffer : ISpanParsable<Buffer>
{
    private int _element0;

    private static ReadOnlySpan<int> GetSpan(ref readonly Buffer buffer)
    => buffer[0..buffer[^1]];

    public bool IsAscending()
    {
        var prev = this[0];
        foreach (var item in GetSpan(ref this)[1..])
            if (item <= prev)
                return false;
            else
                prev = item;
        return true;
    }

    public bool IsDescending()
    {
        var prev = this[0];
        foreach (var item in GetSpan(ref this)[1..])
            if (item >= prev)
                return false;
            else
                prev = item;
        return true;
    }

    public bool HasAcceptableDistance()
    {
        var prev = this[0];
        foreach (var item in GetSpan(ref this)[1..])
            if (Math.Abs(item - prev) is not (>= 1 and <= 3))
                return false;
            else
                prev = item;
        return true;
    }

    public bool IsValid()
    => (IsAscending() || IsDescending()) && HasAcceptableDistance();

    public static Buffer Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        var values = (stackalloc Range[8]);
        values = values[.. s.Split(values, " ")];

        var buffer =  new Buffer();
        buffer[^1] = values.Length;
        for (int i = 0; i < values.Length; i++)
            buffer[i] = int.Parse(s[values[i]]);
        return buffer;
    }

    public static Buffer Parse(string s, IFormatProvider? provider)
    => throw new NotImplementedException();

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Buffer result)
    => throw new NotImplementedException();

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Buffer result)
    => throw new NotImplementedException();
}
