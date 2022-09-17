namespace TicTacToe.Core;

public sealed class Point
{
    private readonly int _x;
    private readonly int _y;

    public Point(
        int x,
        int y)
    {
        _x = x;
        _y = y;
    }

    public static int operator /(
        Point first,
        Point second)
    {
        if (first == null) throw new ArgumentNullException(nameof(first));
        if (second == null) throw new ArgumentNullException(nameof(second));
        
        return (first._x - second._x) / (first._y - second._y);
    }

    public bool Equals(Point point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));
        
        return _x == point._x
               &&
               _y == point._y;
    }

    public IEnumerable<Vector> GenerateVectors(int length)
    {
        if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
        
        for (var i = -length; i < length + 1; i += length)
        for (var j = -length; j < length + 1; j += length)
            if (i != 0 || j != 0)
                yield return new Vector(this, new Point(_x + i, _y + j));
    }

    public double Distance(Point point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));
        
        return Math.Sqrt(Math.Pow(_x - point._x, 2) + Math.Pow(_y - point._y, 2));
    }
}