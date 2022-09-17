using TicTacToe.Core.Vectors;

namespace TicTacToe.Core.Points;

public sealed class TwoDimensionalPoint : IPoint
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public TwoDimensionalPoint(
        int x,
        int y)
    {
        X = x;
        Y = y;
        Z = 0;
    }

    public double Distance(IPoint point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));
        
        return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2) + Math.Pow(Z - point.Z, 2));
    }

    public IEnumerable<IVector> GenerateVectors(int length)
    {
        if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
        
        for (var i = -length; i < length + 1; i += length)
        for (var j = -length; j < length + 1; j += length)
            if (i != 0 || j != 0)
                yield return new TwoDimensionalVector(this, new TwoDimensionalPoint(X + i, Y + j));
    }

    public bool Equals(IPoint point)
    {
        if (point == null) throw new ArgumentNullException(nameof(point));
        
        return X == point.X
               &&
               Y == point.Y
               &&
               Z == point.Z;
    }
}