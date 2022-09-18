using TicTacToe.Core.Points;

namespace TicTacToe.Core.Players;

public interface IPlayer
{
    public string Name { get; }

    public void AddPoint(IPoint point);

    public bool ContainsPoint(IPoint point);

    public bool Vin(int pointVinCount);
}