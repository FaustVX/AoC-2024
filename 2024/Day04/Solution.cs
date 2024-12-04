#nullable enable
namespace AdventOfCode.Y2024.Day04;

[ProblemInfo("Ceres Search", normalizeInput: false)]
public class Solution : ISolver //, IDisplay
{
    public object PartOne(ReadOnlyMemory<char> input)
    {
        var size = Globals.IsTestInput ? 10 : 140;
        var board = input.Span.AsSpan2D(size, size + 1)[.., ..^1];
        ReadOnlySpan<Func<int, int, ReadOnlySpan2D<char>, ReadOnlySpan<char>, bool>> conditions =
        [
            CheckLine,
            CheckColumn,
            CheckDiagonal1,
            CheckDiagonal2,
        ];

        ReadOnlySpan<char> xmas = ['X', 'M', 'A', 'S'];
        ReadOnlySpan<char> samx = ['S', 'A', 'M', 'X'];

        var count = 0;
        for (int x = 0; x < board.Width; x++)
            for (int y = 0; y < board.Height; y++)
                if (board[x, y] is ('X' or 'S') and var start)
                    foreach (var cond in conditions)
                        count += start switch
                        {
                            'X' => cond(x, y, board, xmas),
                            'S' => cond(x, y, board, samx),
                            _ => throw new UnreachableException(),
                        } ? 1 : 0;

        return count;

        static bool CheckLine(int x, int y, ReadOnlySpan2D<char> board, ReadOnlySpan<char> xmas)
        {
            if (x >= board.Width - 3)
                return false;
            for (int i = 1; i < 4; i++)
                if (board[x + i, y] != xmas[i])
                    return false;
            return true;
        }

        static bool CheckColumn(int x, int y, ReadOnlySpan2D<char> board, ReadOnlySpan<char> xmas)
        {
            if (y >= board.Height - 3)
                return false;
            for (int i = 1; i < 4; i++)
                if (board[x, y + i] != xmas[i])
                    return false;
            return true;
        }

        static bool CheckDiagonal1(int x, int y, ReadOnlySpan2D<char> board, ReadOnlySpan<char> xmas)
        {
            if (x >= board.Width - 3 || y >= board.Height - 3)
                return false;
            for (int i = 1; i < 4; i++)
                if (board[x + i, y + i] != xmas[i])
                    return false;
            return true;
        }

        static bool CheckDiagonal2(int x, int y, ReadOnlySpan2D<char> board, ReadOnlySpan<char> xmas)
        {
            if (x < 3 || y >= board.Width - 3)
                return false;
            for (int i = 1; i < 4; i++)
                if (board[x - i, y + i] != xmas[i])
                    return false;
            return true;
        }
    }

    public object PartTwo(ReadOnlyMemory<char> input)
    {
        var size = Globals.IsTestInput ? 10 : 140;
        var board = input.Span.AsSpan2D(size, size + 1)[.., ..^1];
        ReadOnlySpan<Func<int, int, ReadOnlySpan2D<char>, ReadOnlySpan<char>, bool>> conditions =
        [
            CheckDiagonal1,
            CheckDiagonal2,
        ];

        ReadOnlySpan<char> mas = ['M', 'A', 'S'];
        ReadOnlySpan<char> sam = ['S', 'A', 'M'];

        var count = 0;
        for (int x = 1; x < board.Width - 1; x++)
            for (int y = 1; y < board.Height - 1; y++)
                if (board[x, y] is 'A'
                    && (CheckDiagonal1(x, y, board, mas) || CheckDiagonal1(x, y, board, sam))
                    && (CheckDiagonal2(x, y, board, mas) || CheckDiagonal2(x, y, board, sam)))
                    count++;

        return count;

        static bool CheckDiagonal1(int x, int y, ReadOnlySpan2D<char> board, ReadOnlySpan<char> xmas)
        {
            if (x >= board.Width - 1 || y >= board.Height - 1)
                return false;
            x--;
            y--;
            for (int i = 0; i < 3; i++)
                if (board[x + i, y + i] != xmas[i])
                    return false;
            return true;
        }

        static bool CheckDiagonal2(int x, int y, ReadOnlySpan2D<char> board, ReadOnlySpan<char> xmas)
        {
            if (x < 1 || y >= board.Width - 1)
                return false;
            x++;
            y--;
            for (int i = 0; i < 3; i++)
                if (board[x - i, y + i] != xmas[i])
                    return false;
            return true;
        }
    }
}
