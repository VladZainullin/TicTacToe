namespace TicTacToe.Core;

public class Point
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

    public IEnumerable<Line> Lines
    {
        get
        {
            for (var i = -1; i < 2; i ++)
            for (var j = -1; j < 2; j ++)
            {
                if (i != 0 || j != 0)
                    yield return new Line(this, new Point(X + i, Y + j));
            }
        }
    }
}