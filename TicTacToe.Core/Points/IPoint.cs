using TicTacToe.Core.Vectors;

namespace TicTacToe.Core.Points;

public interface IPoint
{
    public int X { get; }
    public int Y { get; }
    
    public int Z { get; }
    
    public bool Equals(IPoint point);

    public IEnumerable<IVector> GenerateVectors(int length);

    public double Distance(IPoint point);
}