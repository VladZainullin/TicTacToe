namespace TicTacToe.Core;

public sealed class Game
{
    private readonly Queue<Player> _players;
    private Player _currentPlayer;

    public Game(IEnumerable<Player> players)
    {
        _players = new Queue<Player>(players);
        _currentPlayer = new Player(_players.Peek().Name);
    }

    public void MadeMove(
        int x,
        int y)
    {
        _currentPlayer = _players.Dequeue();

        foreach (var player in _players)
        {
            if (player.Points.Contains(new Point(x, y)))
                throw new ArgumentOutOfRangeException("Точка уже занята другим игроком");
        }
        
        _currentPlayer.AddPoint(x, y);
        _players.Enqueue(_currentPlayer);
    }

    public Result Check()
    {
        var points = _currentPlayer.Points;

        foreach (var point in points)
        {
            var lines = GenerateLines(point);

            foreach (var line in lines)
            {
                var pointCount = points.Count(p => line.Check(p));

                if (pointCount >= 3)
                    return new Result(false, _currentPlayer.Name);
            }
        }

        return new Result(true, _currentPlayer.Name);
    }

    private static IEnumerable<Line> GenerateLines(Point point)
    {
        var lines = new List<Line>();

        for (var i = -1; i < 2; i++)
        for (var j = -1; j < 2; j++)
        {
            if (i != 0 || j != 0)
                lines.Add(new Line(point, new Point(point.X + i, point.Y + j)));
        }

        return lines;
    }
}