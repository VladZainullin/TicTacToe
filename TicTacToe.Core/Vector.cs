namespace TicTacToe.Core;

public sealed class Vector
{
    private readonly Point _end;
    private readonly Point _start;

    public Vector(
        Point start,
        Point end)
    {
        _start = start ?? throw new ArgumentNullException(nameof(start));
        _end = end ?? throw new ArgumentNullException(nameof(end));
    }

    public double Length => _start.Distance(_end);

    public bool Contains(Point point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));
        try
        {
            return point / _start == _end / _start
                   &&
                   _start.Distance(point) + point.Distance(_end) - _start.Distance(_end) == 0;;
        }
        catch (DivideByZeroException)
        {
            return point.Equals(_start)
                   ||
                   point.Equals(_end);
        }
    }
}