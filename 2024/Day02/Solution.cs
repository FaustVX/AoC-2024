#nullable enable
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Y2024.Day02;

using static System.MemoryExtensions;

[ProblemInfo("Red-Nosed Reports")]
public class Solution : ISolver //, IDisplay
{
    public object PartOne(ReadOnlyMemory<char> input)
    => Execute(input.Span, b => b.IsValidP1());

    public object PartTwo(ReadOnlyMemory<char> input)
    => Execute(input.Span, b => b.IsValidP2());

    static int Execute(ReadOnlySpan<char> input, Func<Buffer, bool> isValid)
    {
        var reports = Extensions.ParseToArray(input, stackalloc Buffer[input.Count('\n') + 1]);
        var count = 0;
        foreach (var item in reports)
            if (isValid(item))
                count++;
        return count;
    }
}

[System.Runtime.CompilerServices.InlineArray(9)]
struct Buffer : ISpanParsable<Buffer>
{
    private int _element0;

    private static ReadOnlySpan<int> GetSpan(ref readonly Buffer buffer)
    => buffer[0..buffer[^1]];

    public readonly bool IsAscending(int badLevel)
    {
        var prev = int.MinValue;
        for (int i = 0; i < this[^1]; i++)
            if (i == badLevel)
                continue;
            else if (this[i] <= prev)
                return false;
            else
                prev = this[i];
        return true;
    }

    public readonly bool IsDescending(int badLevel)
    {
        var prev = int.MaxValue;
        for (int i = 0; i < this[^1]; i++)
            if (i == badLevel)
                continue;
            else if (this[i] >= prev)
                return false;
            else
                prev = this[i];
        return true;
    }

    public readonly bool HasAcceptableDistance(int badLevel)
    {
        var prev = this[badLevel is 0 ? 1 : 0] - 1;
        for (int i = 0; i < this[^1]; i++)
            if (i == badLevel)
                continue;
            else if (Math.Abs(this[i] - prev) is not (>= 1 and <= 3))
                return false;
            else
                prev = this[i];
        return true;
    }

    public readonly bool IsValidP1()
    => (IsAscending(-1) || IsDescending(-1)) && HasAcceptableDistance(-1);

    public readonly bool IsValidP2()
    {
        for (int i = 0; i < this[^1]; i++)
            if ((IsAscending(i) || IsDescending(i)) && HasAcceptableDistance(i))
                return true;
        return false;
    }

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
