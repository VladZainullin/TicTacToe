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
        try
        {
            return (point.X - _start.X) / (_end.X - _start.X) == (point.Y - _start.Y) / (_end.Y - _start.Y)
                   &&
                   (point.Y - _start.Y) / (_end.Y - _start.Y) == (point.Z - _start.Z) / (_end.Z - _start.Z)
                   &&
                   (point.Z - _start.Z) / (_end.Z - _start.Z) == (point.X - _start.X) / (_end.X - _start.X)
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