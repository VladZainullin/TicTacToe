using TicTacToe.Core.Points;

namespace TicTacToe.Core.Vectors;

public interface IVector
{
    public bool Contains(IPoint point);
}