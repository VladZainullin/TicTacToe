namespace TicTacToe.Core;

public sealed class Player
{
    public Player(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public ICollection<Point> Points { get; } = new List<Point>();

    public void AddPoint(
        int x,
        int y)
    {
        var point = new Point(x, y);

        Points.Add(point);
    }
}