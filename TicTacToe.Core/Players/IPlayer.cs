using TicTacToe.Core.Points;

namespace TicTacToe.Core.Players;

public interface IPlayer
{
    public string Name { get; }

    public void AddPoint(IPoint twoDimensionalVectorPoint);

    public bool ContainsPoint(IPoint twoDimensionalVectorPoint);

    public bool Vin(int pointVinCount);
}