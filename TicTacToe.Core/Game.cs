using TicTacToe.Core.Enums;

namespace TicTacToe.Core;

public sealed class Game
{
    private readonly Queue<Player> _players;
    private readonly int _vinPointCount;

    public Game(
        IEnumerable<Player> players,
        int vinPointCount)
    {
        _players = new Queue<Player>(players);
        _vinPointCount = vinPointCount;

        CurrentPlayer = _players.Peek();
        Status = GameStatus.Create;
    }

    public Player CurrentPlayer { get; private set; }
    public GameStatus Status { get; private set; }

    public void MakeMove(
        int x,
        int y)
    {
        var point = new Point(x, y);
        
        CurrentPlayer = _players.Dequeue();

        if (Status != GameStatus.Start)
            Status = GameStatus.Start;

        var occupied = IsOccupied(point);
        if (occupied)
            throw new ArgumentOutOfRangeException("Точка уже занята другим игроком");

        CurrentPlayer.AddPoint(point);

        var vin = CurrentPlayer.Vin(_vinPointCount);
        if (vin)
        {
            Status = GameStatus.Stop;
            return;
        }

        _players.Enqueue(CurrentPlayer);
        CurrentPlayer = _players.Peek();
    }

    private bool IsOccupied(Point point) => _players
            .Any(player => player
                .ContainsPoint(point));
}