namespace TicTacToe.Core;

public sealed class Point
{
    public Point(
        int x,
        int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public static int operator /(
        Point first,
        Point second)
    {
        return (first.X - second.X) / (first.Y - second.Y);
    }

    public IEnumerable<Vector> GenerateVectors(int length)
    {
        for (var i = -length; i < length + 1; i += length)
        for (var j = -length; j < length + 1; j += length)
            if (i != 0 || j != 0)
                yield return new Vector(this, new Point(X + i, Y + j));
    }

    public double Distance(Point point)
    {
        return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
    }
}