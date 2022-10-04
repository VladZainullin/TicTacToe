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

    public bool Contains(Point point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));
        return _start.Distance(point) + point.Distance(_end) - _start.Distance(_end) == 0;
    }
}