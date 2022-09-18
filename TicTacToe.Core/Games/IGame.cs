using TicTacToe.Core.Enums;
using TicTacToe.Core.Players;
using TicTacToe.Core.Points;

namespace TicTacToe.Core.Games;

public interface IGame
{
    public IPlayer CurrentPlayer { get; }
    public GameStatus Status { get; }
    
    public void MakeMove(IPoint point);
}