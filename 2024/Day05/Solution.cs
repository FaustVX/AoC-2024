#nullable enable
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AdventOfCode.Y2024.Day05;

[ProblemInfo("Print Queue")]
public class Solution : ISolver //, IDisplay
{
    public object PartOne(ReadOnlyMemory<char> input)
    {
        var (orders, updates) = input.Span.ParseToArray<Order, Update>();
        var sum = 0;
        foreach (var update in updates)
        {
            bool isValid = true;
            var span = Update.GetROSpan(in update);
            foreach (var (f, s) in orders)
                if ((span.IndexOf(f), span.IndexOf(s)) is (>= 0 and var a, >= 0 and var b) && a > b)
                {
                    isValid = false;
                    break;
                }
            if (isValid)
                sum += update.GetMiddle();
        }
        return sum;
    }

    public object PartTwo(ReadOnlyMemory<char> input)
    {
        return 0;
    }
}

readonly record struct Order(int First, int Second) : ISpanParsable<Order>
{
    public static Order Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    => new(int.Parse(s.Slice(0, 2)), int.Parse(s.Slice(3, 2)));

    public static Order Parse(string s, IFormatProvider? provider)
    => throw new NotImplementedException();

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Order result)
    => throw new NotImplementedException();

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Order result)
    => throw new NotImplementedException();
}

[InlineArray(25)]
struct Update : ISpanParsable<Update>
{
    private int _element0;

    public static ReadOnlySpan<int> GetROSpan(ref readonly Update buffer)
    => GetSpan(in buffer);

    private static Span<int> GetSpan(ref readonly Update buffer)
    => MemoryMarshal.CreateSpan(ref Unsafe.AsRef(in buffer[1]), buffer[0]);

    public readonly int GetMiddle()
    => GetROSpan(in this)[this[0] / 2];

    public static Update Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        var values = (stackalloc Range[24]);
        values = values[.. s.Split(values, ",")];

        var buffer = new Update();
        buffer[0] = values.Length;
        var span = GetSpan(in buffer);
        for (int i = 0; i < values.Length; i++)
            span[i] = int.Parse(s[values[i]]);
        return buffer;
    }

    public static Update Parse(string s, IFormatProvider? provider)
    => throw new NotImplementedException();

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out Update result)
    => throw new NotImplementedException();

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Update result)
    => throw new NotImplementedException();
}
