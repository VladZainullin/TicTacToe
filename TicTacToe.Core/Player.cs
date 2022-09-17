namespace TicTacToe.Core;

public sealed class Player
{
    private readonly List<Point> _points;
    public Player(string name)
    {
        Name = name;
        _points = new List<Point>();
    }

    public string Name { get; }

    public void AddPoint(Point point) => _points.Add(point);

    public bool ContainsPoint(Point point) => _points.Contains(point);
    
    public bool Vin(int pointVinCount) => _points
        .Select(point => point
            .GenerateVectors(pointVinCount + 1)
            .Select(v => _points
                .Count(p =>
                    v.Contains(p)
                    &&
                    !p.Equals(point)))
            .All(count => count < pointVinCount - 1))
        .All(b => !b);
}