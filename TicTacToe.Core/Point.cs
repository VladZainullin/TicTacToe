namespace TicTacToe.Core;

public struct Point
{
    public Point(
        int x,
        int y)
    {
        X = x;
        Y = y;
    }

    internal int X { get; }
    internal int Y { get; }
    
    public static int operator /(
        Point first,
        Point second)
    {
        return (first.X - second.X) / (first.Y - second.Y);
    }
}