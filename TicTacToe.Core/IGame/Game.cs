using TicTacToe.Core.Enums;
using TicTacToe.Core.Players;
using TicTacToe.Core.Points;

namespace TicTacToe.Core.IGame;

public sealed class Game : IGame
{
    private readonly Queue<IPlayer> _players;
    private readonly int _vinPointCount;

    public Game(
        IEnumerable<IPlayer> players,
        int vinPointCount)
    {
        _players = new Queue<IPlayer>(players);
        _vinPointCount = vinPointCount;

        CurrentPlayer = _players.Peek();
        Status = GameStatus.Create;
    }

    public IPlayer CurrentPlayer { get; private set; }
    public GameStatus Status { get; private set; }

    public void MakeMove(IPoint twoDimensionalVectorPoint)
    {
        CurrentPlayer = _players.Dequeue();

        if (Status != GameStatus.Start)
            Status = GameStatus.Start;

        var occupied = IsOccupied(twoDimensionalVectorPoint);
        if (occupied)
            throw new ArgumentOutOfRangeException("Точка уже занята другим игроком");

        CurrentPlayer.AddPoint(twoDimensionalVectorPoint);

        var vin = CurrentPlayer.Vin(_vinPointCount);
        if (vin)
        {
            Status = GameStatus.Stop;
            return;
        }

        _players.Enqueue(CurrentPlayer);
        CurrentPlayer = _players.Peek();
    }

    private bool IsOccupied(IPoint twoDimensionalVectorPoint) => _players
            .Any(player => player
                .ContainsPoint(twoDimensionalVectorPoint));
}