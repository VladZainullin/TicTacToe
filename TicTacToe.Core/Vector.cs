namespace TicTacToe.Core;

public sealed class Vector
{
    private readonly Point _end;
    private readonly Point _start;

    public Vector(
        Point start,
        Point end)
    {
        _start = start;
        _end = end;
    }

    public double Length => _start.Distance(_end);

    public bool Contains(Point point)
    {
        try
        {
            var contains =
                point / _start == _end / _start;

            return contains;
        }
        catch (DivideByZeroException)
        {
            return false;
        }
    }
}