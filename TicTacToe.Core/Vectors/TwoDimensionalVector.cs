using TicTacToe.Core.Points;

namespace TicTacToe.Core.Vectors;

public sealed class TwoDimensionalVector : IVector
{
    private readonly IPoint _end;
    private readonly IPoint _start;

    public TwoDimensionalVector(
        IPoint start,
        IPoint end)
    {
        _start = start ?? throw new ArgumentNullException(nameof(start));
        _end = end ?? throw new ArgumentNullException(nameof(end));
    }

    public bool Contains(IPoint point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));

        return _start.Distance(point) + point.Distance(_end) - _start.Distance(_end) == 0;
    }
}