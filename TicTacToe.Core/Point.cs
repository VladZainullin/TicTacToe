namespace TicTacToe.Core;

public sealed class Point
{
    private readonly int _x;
    private readonly int _y;
    private readonly int _z;

    public Point(
        int x,
        int y,
        int z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    public bool Equals(Point point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));

        if (this == point)
            return true;

        return _x == point._x
               &&
               _y == point._y
               &&
               _z == point._z;
    }

    public IEnumerable<Vector> GenerateVectors(int length)
    {
        if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));

        for (var i = -length; i < length + 1; i += length)
        for (var j = -length; j < length + 1; j += length)
        for (var z = -length; z < length + 1; z += length)
            if (i != 0 || j != 0 || z != 0)
                yield return new Vector(this, new Point(_x + i, _y + j, _z + z));
    }

    public double Distance(Point point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));

        return Math.Sqrt(Math.Pow(_x - point._x, 2) + Math.Pow(_y - point._y, 2) + Math.Pow(_z - point._z, 2));
    }
}