#nullable enable
namespace AdventOfCode.Y2024.Day03;

[ProblemInfo("Mull It Over")]
public partial class Solution : ISolver //, IDisplay
{
    public object PartOne(ReadOnlyMemory<char> input)
    {
        var sum = 0;
        var ranges = (stackalloc Range[2]);
        foreach (var line in input.Span.EnumerateLines())
            foreach (var (i, l) in ParseMul.EnumerateMatches(line))
            {
                var match = line.Slice(i, l)[4..^1];
                match.Split(ranges, ",");
                sum += int.Parse(match[ranges[0]]) * int.Parse(match[ranges[1]]);
            }
        return sum;
    }

    public object PartTwo(ReadOnlyMemory<char> input)
    {
        return 0;
    }

    [GeneratedRegex("""mul\((\d+),(\d+)\)""")]
    static partial Regex ParseMul { get; }
}

file static class Ext
{
    public static void Deconstruct(this ValueMatch match, out int index, out int length)
    => (index, length) = (match.Index, match.Length);
}