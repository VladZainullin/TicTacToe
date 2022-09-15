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
}