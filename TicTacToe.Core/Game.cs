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

    public void MadeMove(
        int x,
        int y)
    {
        CurrentPlayer = _players.Dequeue();

        if (Status != GameStatus.Start)
            Status = GameStatus.Start;

        var occupied = IsOccupied(x, y);
        if (occupied)
            throw new ArgumentOutOfRangeException("Точка уже занята другим игроком");

        CurrentPlayer.AddPoint(x, y);

        var points = CurrentPlayer.Points;

        foreach (var point in points)
        foreach (var vector in point.GenerateVectors(_vinPointCount))
        {
            var pointCount = points.Count(p => vector.Contains(p));

            if (pointCount < _vinPointCount - 1)
                continue;

            Status = GameStatus.Stop;
            return;
        }

        _players.Enqueue(CurrentPlayer);
        CurrentPlayer = _players.Peek();
    }

    private bool IsOccupied(
        int x,
        int y)
    {
        return _players
            .Any(player => player
                .Points
                .Contains(new Point(x, y)));
    }
}