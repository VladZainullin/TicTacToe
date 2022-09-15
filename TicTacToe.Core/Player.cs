namespace TicTacToe.Core;

public sealed class Player
{
    public string Name { get; }

    public Player(string name)
    {
        Name = name;
    }
    public ICollection<Point> Points { get; } = new List<Point>();

    public void AddPoint(
        int x,
        int y)
    {
        var cell = new Point(x, y);
        
        Points.Add(cell);
    }
}