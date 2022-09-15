namespace TicTacToe.Core;

public sealed class Game
{
    private readonly Queue<Player> _players;

    public Game(IEnumerable<Player> players)
    {
        _players = new Queue<Player>(players);
        CurrentPlayer = new Player(_players.Peek().Name);
    }

    public void MadeMove(
        int x,
        int y)
    {
        CurrentPlayer = _players.Dequeue();

        foreach (var player in _players)
        {
            if (player.Points.Contains(new Point(x, y)))
                throw new ArgumentOutOfRangeException("Точка уже занята другим игроком");
        }
        
        CurrentPlayer.AddPoint(x, y);
        _players.Enqueue(CurrentPlayer);
    }

    public Player CurrentPlayer { get; private set; }

    public Result Check()
    {
        var points = CurrentPlayer.Points;

        foreach (var point in points)
        {
            var lines = GenerateLines(point);

            foreach (var line in lines)
            {
                var pointCount = points.Count(p => line.Check(p));

                if (pointCount >= 3)
                    return new Result(false, CurrentPlayer.Name);
            }
        }

        return new Result(true, CurrentPlayer.Name);
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