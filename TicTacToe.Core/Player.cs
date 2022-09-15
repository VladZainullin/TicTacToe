namespace TicTacToe.Core;

public sealed class Player
{
    internal string Name { get; }

    public Player(string name)
    {
        Name = name;
    }
    internal ICollection<Point> Points { get; } = new List<Point>();

    public void AddPoint(
        int x,
        int y)
    {
        var cell = new Point(x, y);
        
        Points.Add(cell);
    }
}